using ITControl.Application.Appointments.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Appointments.Params;

public record DeleteAppointmentsParams
{
    [FromRoute(Name = "id")]
    public Guid Id { get; set; }

    public static implicit operator DeleteAppointmentsServiceParams(
        DeleteAppointmentsParams presentationParams) =>
        new()
        {
            Id = presentationParams.Id
        };
}
