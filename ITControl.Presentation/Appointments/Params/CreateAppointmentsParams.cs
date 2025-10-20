using ITControl.Application.Appointments.Params;
using ITControl.Communication.Appointments.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Appointments.Params;

public record CreateAppointmentsParams
{
    [FromBody]
    public CreateAppointmentsRequest Request { get; set; } = new();

    public static implicit operator CreateAppointmentsServiceParams(
        CreateAppointmentsParams paramsWrapper) =>
        new()
        {
            Params = paramsWrapper.Request
        };
}
