using ITControl.Application.Shared.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Appointments.Params;

public record DeleteAppointmentsParams
{
    [FromRoute(Name = "id")]
    public Guid Id { get; set; }

    public static implicit operator DeleteServiceParams(
        DeleteAppointmentsParams presentationParams) =>
        new()
        {
            Id = presentationParams.Id
        };
}
