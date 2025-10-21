using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Notifications.Params;

public record OrderByNotificationsRepositoryParams :
    OrderByRepositoryParams
{
    public string? Title { get; set; } = null;
    public string? Message { get; set; } = null;
    public string? Type { get; set; } = null;
    public string? Reference { get; set; } = null;
    public string? IsRead { get; set; } = null;
    public string? User { get; set; } = null;
    public string? CreatedAt { get; set; } = null;
}
