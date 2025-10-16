using ITControl.Domain.Notifications.Enums;

namespace ITControl.Domain.Notifications.Params;

public record NotificationParams
{
    public string Title { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public NotificationType Type { get; set; }
    public NotificationReference Reference { get; set; }
    public Guid UserId { get; set; }
    public Guid? CallId { get; set; } = null;
    public Guid? AppointmentId { get; set; } = null;
    public Guid? TreatmentId { get; set; } = null;
}
