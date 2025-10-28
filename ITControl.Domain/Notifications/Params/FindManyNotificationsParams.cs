using ITControl.Domain.Notifications.Enums;
using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Notifications.Params;

public record FindManyNotificationsParams :
    FindManyParams
{
    public string? Title { get; init; }
    public string? Message { get; init; }
    public NotificationType? Type { get; init; }
    public NotificationReference? Reference { get; init; }
    public bool? IsRead { get; init; }
    public Guid? UserId { get; init; }
    public DateTime? CreatedAt { get; init; }
}
