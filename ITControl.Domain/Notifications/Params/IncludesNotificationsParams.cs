using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Notifications.Params;

public record IncludesNotificationsParams : IncludesParams
{
    public bool? User { get; set; } = null;
    public bool? Call { get; set; } = null;
    public bool? Appointment { get; set; } = null;
    public bool? Treatment { get; set; } = null;
}
