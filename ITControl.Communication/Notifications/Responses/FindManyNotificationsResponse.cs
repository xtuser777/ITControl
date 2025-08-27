using ITControl.Communication.Shared.Responses;

namespace ITControl.Communication.Notifications.Responses;

public class FindManyNotificationsResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public TranslatableField Type { get; set; } = null!;
    public TranslatableField Reference { get; set; } = null!;
    public bool IsRead { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ReadAt { get; set; }
}
