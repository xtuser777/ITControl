using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Notifications.Params;

public record IncludesNotificationsParams : IncludesParams
{
    public bool? User { get; set; }
    public bool? Call { get; set; }
    public bool? Appointment { get; set; }
    public bool? Treatment { get; set; }
}
