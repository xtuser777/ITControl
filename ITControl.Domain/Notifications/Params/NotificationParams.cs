using ITControl.Domain.Notifications.Enums;

namespace ITControl.Domain.Notifications.Params;

public record NotificationParams
{
    public string Title { get; init; } = string.Empty;
    public string Message { get; init; } = string.Empty;
    public NotificationType Type { get; init; }
    public NotificationReference Reference { get; init; }
    public Guid UserId { get; init; }
    public Guid? CallId { get; init; } = null;
    public Guid? AppointmentId { get; init; } = null;
    public Guid? TreatmentId { get; init; } = null;
}
