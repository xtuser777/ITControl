using ITControl.Domain.Notifications.Params;

namespace ITControl.Communication.Notifications.Requests;

public record OrderByNotificationsRequest
{
    public string? Title { get; set; }
    public string? Message { get; set; }
    public string? Type { get; set; }
    public string? Reference { get; set; }
    public string? IsRead { get; set; }
    public string? User { get; set; }
    public string? CreatedAt { get; set; }

    public static implicit operator OrderByNotificationsRepositoryParams(OrderByNotificationsRequest request)
    {
        return new OrderByNotificationsRepositoryParams
        {
            Title = request.Title,
            Message = request.Message,
            Type = request.Type,
            Reference = request.Reference,
            IsRead = request.IsRead,
            User = request.User,
            CreatedAt = request.CreatedAt
        };
    }
}
