using ITControl.Communication.Notifications.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Notifications.Headers;

public record OrderByNotificationsHeaders
{
    [FromHeader(Name = "X-Order-By-Title")]
    public string? Title { get; set; }

    [FromHeader(Name = "X-Order-By-Message")]
    public string? Message { get; set; }

    [FromHeader(Name = "X-Order-By-Type")]
    public string? Type { get; set; }

    [FromHeader(Name = "X-Order-By-Reference")]
    public string? Reference { get; set; }

    [FromHeader(Name = "X-Order-By-Is-Read")]
    public string? IsRead { get; set; }

    [FromHeader(Name = "X-Order-By-User")]
    public string? User { get; set; }

    [FromHeader(Name = "X-Order-By-Created-At")]
    public string? CreatedAt { get; set; }

    public static implicit operator OrderByNotificationsRequest(OrderByNotificationsHeaders request)
    {
        return new OrderByNotificationsRequest
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
