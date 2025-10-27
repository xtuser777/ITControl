using ITControl.Application.Shared.Params;
using ITControl.Domain.Notifications.Enums;
using ITControl.Domain.Notifications.Params;
using ITControl.Domain.Shared.Params;
using ITControl.Domain.Shared.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Notifications.Params;

public record IndexNotificationsParams : PaginationParams
{
    public string? Title { get; init; }
    public string? Message { get; init; }
    public string? Type { get; init; }
    public string? Reference { get; init; }
    public bool? IsRead { get; init; }
    public Guid? UserId { get; init; }
    public DateTime? CreatedAt { get; init; }
    
    [FromHeader(Name = "X-Order-By-Title")]
    public string? OrderByTitle { get; init; }
    
    [FromHeader(Name = "X-Order-By-Message")]
    public string? OrderByMessage { get; init; }
    
    [FromHeader(Name = "X-Order-By-Type")]
    public string? OrderByType { get; init; }
    
    [FromHeader(Name = "X-Order-By-Reference")]
    public string? OrderByReference { get; init; }
    
    [FromHeader(Name = "X-Order-By-Is-Read")]
    public string? OrderByIsRead { get; init; }
    
    [FromHeader(Name = "X-Order-By-User")]
    public string? OrderByUser { get; init; }
    
    [FromHeader(Name = "X-Order-By-Created-At")]
    public string? OrderByCreatedAt { get; init; }

    public static implicit operator OrderByNotificationsParams(
        IndexNotificationsParams request)
    {
        return new OrderByNotificationsParams
        {
            Title = request.OrderByTitle,
            Message = request.OrderByMessage,
            Type = request.OrderByType,
            Reference = request.OrderByReference,
            IsRead = request.OrderByIsRead,
            User = request.OrderByUser,
            CreatedAt = request.OrderByCreatedAt
        };
    }

    public static implicit operator FindManyNotificationsParams(
        IndexNotificationsParams request)
    {
        return new FindManyNotificationsParams
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

    public static implicit operator CountNotificationsParams(
        IndexNotificationsParams request)
    {
        return new CountNotificationsParams
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

    public static implicit operator FindManyServiceParams(
        IndexNotificationsParams param)
        => new()
        {
            FindManyParams = param,
            OrderByParams = param,
            PaginationParams = param
        };

    public static implicit operator FindManyPaginationServiceParams(
        IndexNotificationsParams param)
        => new()
        {
            CountParams = param,
            PaginationParams = param
        };
}