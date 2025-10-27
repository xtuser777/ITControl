using ITControl.Application.Shared.Params;
using ITControl.Domain.Notifications.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Notifications.Params;

public record ShowNotificationsParams
{
    [FromRoute]
    public Guid Id { get; init; }
    
    [FromQuery]
    public bool? IncludeAppointment { get; init; } = true;
    [FromQuery]
    public bool? IncludeCall { get; init; } = true;
    [FromQuery]
    public bool? IncludeTreatment { get; init; } = true;

    public static implicit operator FindOneServiceParams(
        ShowNotificationsParams param)
        => new()
        {
            Id = param.Id,
            Includes = new IncludesNotificationsParams
            {
                Appointment = param.IncludeAppointment,
                Call = param.IncludeCall,
                Treatment = param.IncludeTreatment
            }
        };
}