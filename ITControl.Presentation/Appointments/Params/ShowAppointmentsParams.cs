using ITControl.Application.Shared.Params;
using ITControl.Domain.Appointments.Params;
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

    public static implicit operator FindOneServiceParams(
        ShowAppointmentsParams showParams) =>
        new()
        {
            Id = showParams.Id,
            Includes = new IncludesAppointmentsParams
            {
                Call = showParams.IncludeCall ?? true,
                User = showParams.IncludeUser ?? true
            }
        };
}
