using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Notifications.Params;

public record OrderByNotificationsParams :
    OrderByParams
{
    public string? Title { get; init; }
    public string? Message { get; init; }
    public string? Type { get; init; }
    public string? Reference { get; init; }
    public string? IsRead { get; init; }
    public string? User { get; init; }
    public string? CreatedAt { get; init; }
}
