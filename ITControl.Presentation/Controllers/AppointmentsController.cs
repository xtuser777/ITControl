using ITControl.Application.Appointments.Interfaces;
using ITControl.Communication.Appointments.Requests;
using ITControl.Communication.Appointments.Responses;
using ITControl.Communication.Shared.Responses;
using ITControl.Presentation.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Controllers
{
    [Route("appointments")]
    [ApiController]
    [PermissionsFilter]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AppointmentsController(
        IAppointmentsService appointmentsService,
        IAppointmentsView appointmentsView) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(FindManyResponse<FindManyAppointmentsResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        public async Task<FindManyResponse<FindManyAppointmentsResponse>> IndexAsync(
            [FromQuery] FindManyAppointmentsRequest request)
        {
            var appointments = await appointmentsService.FindManyAsync(request);
            var pagination = await appointmentsService.FindManyPaginationAsync(request);
            var data = appointmentsView.FindMany(appointments);

            return new FindManyResponse<FindManyAppointmentsResponse>()
            {
                Data = data,
                Pagination = pagination,
            };
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(FindOneResponse<FindOneAppointmentsResponse?>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        public async Task<FindOneResponse<FindOneAppointmentsResponse?>> FindOneAsync(Guid id)
        {
            var appointment = await appointmentsService.FindOneAsync(id, true, true, true);
            var data = appointmentsView.FindOne(appointment);

            return new FindOneResponse<FindOneAppointmentsResponse?>()
            {
                Data = data,
            };
        }

        [HttpPost]
        [ProducesResponseType(typeof(FindOneResponse<CreateAppointmentsResponse?>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        public async Task<FindOneResponse<CreateAppointmentsResponse?>> CreateAsync(
            [FromBody] CreateAppointmentsRequest request)
        {
            var appointment = await appointmentsService.CreateAsync(request);
            var data = appointmentsView.Create(appointment);
            Response.StatusCode = StatusCodes.Status201Created;
            return new FindOneResponse<CreateAppointmentsResponse?>()
            {
                Data = data,
            };
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        public async Task UpdateAsync(
            Guid id, 
            [FromBody] UpdateAppointmentsRequest request)
        {
            await appointmentsService.UpdateAsync(id, request);
            Response.StatusCode = StatusCodes.Status204NoContent;
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        public async Task DeleteAsync(Guid id)
        {
            await appointmentsService.DeleteAsync(id);
            Response.StatusCode = StatusCodes.Status204NoContent;
        }
    }
}
