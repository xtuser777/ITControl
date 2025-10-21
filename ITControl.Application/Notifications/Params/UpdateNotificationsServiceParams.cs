using ITControl.Domain.Notifications.Params;

namespace ITControl.Application.Notifications.Params;

public record UpdateNotificationsServiceParams
{
    public Guid Id { get; set; }
    public UpdateNotificationParams Params { get; set; } = new();

    public static implicit operator FindOneNotificationsServiceParams(
        UpdateNotificationsServiceParams param)
        => new()
        {
            Id = param.Id,
        };
}