using ITControl.Application.Shared.Params;
using ITControl.Presentation.Appointments.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Appointments.Params;

public record UpdateAppointmentsParams
{
    [FromRoute]
    public Guid Id { get; set; }
    [FromBody]
    public UpdateAppointmentsRequest Request { get; set; } = new();

    public static implicit operator UpdateServiceParams(
        UpdateAppointmentsParams presentationParams) =>
        new()
        {
            Id = presentationParams.Id,
            Params = presentationParams.Request
        };
}
