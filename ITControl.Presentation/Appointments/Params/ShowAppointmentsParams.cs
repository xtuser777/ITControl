using ITControl.Application.Appointments.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Appointments.Params;

public record ShowAppointmentsParams
{
    [FromRoute]
    public Guid Id { get; set; }

    [FromQuery]
    public bool? IncludeCall { get; set; } = true;

    [FromQuery]
    public bool? IncludeUser { get; set; } = true;

    public static implicit operator FindOneAppointmentsServiceParams(
        ShowAppointmentsParams showParams) =>
        new()
        {
            Id = showParams.Id,
            Includes = new()
            {
                Call = showParams.IncludeCall ?? true,
                User = showParams.IncludeUser ?? true
            }
        };
}
