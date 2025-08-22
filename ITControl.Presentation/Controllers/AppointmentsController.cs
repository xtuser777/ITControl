using ITControl.Application.Interfaces;
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
        public async Task<FindManyResponse<FindManyAppointmentsResponse>> Index(
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
        public async Task<FindOneResponse<FindOneAppointmentsResponse?>> FindOne(Guid id)
        {
            var appointment = await appointmentsService.FindOneAsync(id, true, true, true);
            var data = appointmentsView.FindOne(appointment);

            return new FindOneResponse<FindOneAppointmentsResponse?>()
            {
                Data = data,
            };
        }

        [HttpPost]
        public async Task<FindOneResponse<CreateAppointmentsResponse?>> Create(
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
        public async Task Update(Guid id, [FromBody] UpdateAppointmentsRequest request)
        {
            await appointmentsService.UpdateAsync(id, request);
            Response.StatusCode = StatusCodes.Status204NoContent;
        }

        [HttpDelete("{id:guid}")]
        public async Task Delete(Guid id)
        {
            await appointmentsService.DeleteAsync(id);
            Response.StatusCode = StatusCodes.Status204NoContent;
        }
    }
}
