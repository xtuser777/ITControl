using ITControl.Application.Appointments.Interfaces;
using ITControl.Application.Calls.Interfaces;
using ITControl.Application.Notifications.Interfaces;
using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Params;
using ITControl.Domain.Appointments.Entities;
using ITControl.Domain.Appointments.Params;
using ITControl.Presentation.Appointments.Interfaces;
using ITControl.Presentation.Appointments.Params;
using ITControl.Presentation.Appointments.Responses;
using ITControl.Presentation.Shared.Attributes;
using ITControl.Presentation.Shared.Filters;
using ITControl.Presentation.Shared.Responses;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Appointments.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [PermissionsFilter]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AppointmentsController(
        IAppointmentsService appointmentsService,
        IAppointmentsView appointmentsView,
        IWebSocketService webSocketService,
        INotificationsService notificationsService,
        ICallsService callsService) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(
            typeof(FindManyResponse<FindManyAppointmentsResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> IndexAsync(
            [AsParameters] IndexAppointmentsParams @params)
        {
            var appointments = await appointmentsService.FindManyAsync(@params);
            var pagination = await appointmentsService.FindManyPaginationAsync(@params);
            var data = appointmentsView.FindMany(appointments);
            return Ok(new { Data = data, Pagination = pagination });
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(
            typeof(FindOneResponse<FindOneAppointmentsResponse?>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> ShowAsync(
            [AsParameters] ShowAppointmentsParams @params)
        {
            var appointment = await appointmentsService.FindOneAsync(@params);
            var data = appointmentsView.FindOne(appointment);
            return Ok(new { Data = data });
        }

        [HttpGet("check-todays")]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> CheckTodaysAsync([ModelBinder(BinderType = typeof(UserIdAttribute))] Guid userId)
        {
            await appointmentsService.CheckTodaysAsync(userId);
            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType(
            typeof(FindOneResponse<CreateAppointmentsResponse?>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> CreateAsync(
            [AsParameters] CreateAppointmentsParams @params)
        {
            if (@params.Request.CallId == null)
            {
                if (@params.Request.Call != null)
                {
                    var createParams = new CreateServiceParams
                    {
                        Props = @params.Request.Call,
                    };
                    var call = await callsService.CreateAsync(createParams);
                    @params.Request.CallId = call?.Id;
                }
                else
                {
                    throw new ArgumentException("Either CallId or Call must be provided.");
                }
            }
            var appointment = await appointmentsService.CreateAsync(@params);
            var data = appointmentsView.Create(appointment);
            var uri = $"/appointments/{appointment?.Id}";
            if (appointment is not null)
            {
                var userId = appointment.Call?.UserId ?? Guid.Empty;
                var unreadNotifications = 
                    await notificationsService.CountUnreadAsync(userId);
                if (webSocketService.ContainsKey(userId.ToString()))
                {
                    await webSocketService.EchoAsync(
                        userId.ToString(), 
                        unreadNotifications.ToString());
                }
            }
            return Created(uri, new { Data = data });
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> UpdateAsync(
            [AsParameters] UpdateAppointmentsParams @params)
        {
            await appointmentsService.UpdateAsync(@params);
            var call = await callsService.FindOneAsync(
                new FindOneServiceParams { 
                    Id = (Guid)@params.Request.CallId!
                });
            if (call is not null)
            {
                var userId = call.UserId ?? Guid.Empty;
                var unreadNotifications =
                    await notificationsService.CountUnreadAsync(userId);
                if (webSocketService.ContainsKey(userId.ToString()))
                {
                    await webSocketService.EchoAsync(
                        userId.ToString(),
                        unreadNotifications.ToString());
                }
            }
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> DeleteAsync(
            [AsParameters] DeleteAppointmentsParams @params)
        {
            var findOneParams = new FindOneServiceParams { Id = @params.Id };
            var appointment = await appointmentsService.FindOneAsync(findOneParams);
            var callId = appointment!.CallId;
            await appointmentsService.DeleteAsync(@params);
            var call = await callsService.FindOneAsync(
                new FindOneServiceParams
                {
                    Id = (Guid)callId!
                });
            if (call is not null)
            {
                var userId = call.UserId ?? Guid.Empty;
                var unreadNotifications =
                    await notificationsService.CountUnreadAsync(userId);
                if (webSocketService.ContainsKey(userId.ToString()))
                {
                    await webSocketService.EchoAsync(
                        userId.ToString(),
                        unreadNotifications.ToString());
                }
            }
            var userId1 = @params.UserId;
            var unreadNotifications1 =
                await notificationsService.CountUnreadAsync(userId1);
            if (webSocketService.ContainsKey(userId1.ToString()))
            {
                await webSocketService.EchoAsync(
                    userId1.ToString(),
                    unreadNotifications1.ToString());
            }
            return NoContent();
        }
    }
}
