using ITControl.Communication.Shared.Requests;

namespace ITControl.Communication.Notifications.Requests;

public record FindManyNotificationsRequest : PageableRequest
{
    public string? Title { get; set; }
    public string? Message { get; set; }
    public string? Type { get; set; }
    public string? Reference { get; set; }
    public bool? IsRead { get; set; }
    public Guid? UserId { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string? OrderByTitle { get; set; }
    public string? OrderByMessage { get; set; }
    public string? OrderByType { get; set; }
    public string? OrderByReference { get; set; }
    public string? OrderByIsRead { get; set; }
    public string? OrderByUser { get; set; }
    public string? OrderByCreatedAt { get; set; }
}
