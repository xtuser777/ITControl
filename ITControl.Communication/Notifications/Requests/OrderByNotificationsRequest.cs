using ITControl.Domain.Notifications.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Communication.Notifications.Requests;

public record OrderByNotificationsRequest
{
    [FromHeader(Name = "X-Order-By-Title")]
    public string? Title { get; init; }
    
    [FromHeader(Name = "X-Order-By-Message")]
    public string? Message { get; init; }
    
    [FromHeader(Name = "X-Order-By-Type")]
    public string? Type { get; init; }
    
    [FromHeader(Name = "X-Order-By-Reference")]
    public string? Reference { get; init; }
    
    [FromHeader(Name = "X-Order-By-Is-Read")]
    public string? IsRead { get; init; }
    
    [FromHeader(Name = "X-Order-By-User")]
    public string? User { get; init; }
    
    [FromHeader(Name = "X-Order-By-Created-At")]
    public string? CreatedAt { get; init; }

    public static implicit operator OrderByNotificationsRepositoryParams(
        OrderByNotificationsRequest request)
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
