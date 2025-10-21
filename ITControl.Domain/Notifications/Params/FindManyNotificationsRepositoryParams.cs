using ITControl.Domain.Notifications.Enums;
using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Notifications.Params;

public record FindManyNotificationsRepositoryParams :
    FindManyRepositoryParams
{
    public string? Title { get; set; } = null;
    public string? Message { get; set; } = null;
    public NotificationType? Type { get; set; } = null;
    public NotificationReference? Reference { get; set; } = null;
    public bool? IsRead { get; set; } = null;
    public Guid? UserId { get; set; } = null;
    public DateTime? CreatedAt { get; set; } = null;
}
