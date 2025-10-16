using ITControl.Domain.Notifications.Enums;

namespace ITControl.Domain.Notifications.Params;

public record UpdateNotificationParams
{
    public string? Title { get; set; } = null;
    public string? Message { get; set; } = null;
    public NotificationType? Type { get; set; } = null;
    public NotificationReference? Reference { get; set; } = null;
    public bool? IsRead { get; set; } = null;
    public Guid? UserId { get; set; } = null;
    public Guid? CallId { get; set; } = null;
    public Guid? AppointmentId { get; set; } = null;
    public Guid? TreatmentId { get; set; } = null;
}
