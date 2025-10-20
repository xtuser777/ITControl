using ITControl.Application.Appointments.Interfaces;
using ITControl.Communication.Appointments.Requests;
using ITControl.Communication.Appointments.Responses;
using ITControl.Communication.Shared.Responses;
using ITControl.Presentation.Appointments.Params;
using ITControl.Presentation.Shared.Filters;
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
        IAppointmentsView appointmentsView) : ControllerBase
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
        public async Task<IActionResult> FindOneAsync(
            [AsParameters] ShowAppointmentsParams @params)
        {
            var appointment = await appointmentsService.FindOneAsync(@params);
            var data = appointmentsView.FindOne(appointment);
            return Ok(new { Data = data });
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
            var appointment = await appointmentsService.CreateAsync(@params);
            var data = appointmentsView.Create(appointment);
            var uri = Url.Action(
                nameof(FindOneAsync),
                values: new { id = data?.Id }) ?? string.Empty;
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
            await appointmentsService.DeleteAsync(@params);
            return NoContent();
        }
    }
}
