using ITControl.Communication.Shared.Requests;
using ITControl.Communication.Shared.Utils;
using ITControl.Domain.Notifications.Enums;
using ITControl.Domain.Notifications.Params;
using ITControl.Domain.Shared.Params;

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

    public static implicit operator FindManyNotificationsRepositoryParams(
        FindManyNotificationsRequest request)
    {
        return new FindManyNotificationsRepositoryParams
        {
            Title = request.Title,
            Message = request.Message,
            Type = Parser.ToEnumOptional<NotificationType>(request.Type),
            Reference = Parser.ToEnumOptional<NotificationReference>(request.Reference),
            IsRead = request.IsRead,
            UserId = request.UserId,
            CreatedAt = request.CreatedAt
        };
    }

    public static implicit operator CountNotificationsRepositoryParams(
        FindManyNotificationsRequest request)
    {
        return new CountNotificationsRepositoryParams
        {
            Title = request.Title,
            Message = request.Message,
            Type = Parser.ToEnumOptional<NotificationType>(request.Type),
            Reference = Parser.ToEnumOptional<NotificationReference>(request.Reference),
            IsRead = request.IsRead,
            UserId = request.UserId,
            CreatedAt = request.CreatedAt
        };
    }

    public static implicit operator PaginationParams(
        FindManyNotificationsRequest request)
    {
        return new PaginationParams
        {
            Page = Parser.ToIntOptional(request.Page),
            Size = Parser.ToIntOptional(request.Size),
        };
    }
}
