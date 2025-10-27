using ITControl.Domain.Notifications.Enums;
using ITControl.Domain.Shared.Params2;

namespace ITControl.Domain.Notifications.Params;

public record NotificationParams : EntityParams
{
    public string Title { get; init; } = string.Empty;
    public string Message { get; init; } = string.Empty;
    public NotificationType Type { get; init; }
    public NotificationReference Reference { get; init; }
    public Guid UserId { get; init; }
    public Guid? CallId { get; init; }
    public Guid? AppointmentId { get; init; }
    public Guid? TreatmentId { get; init; }
}
