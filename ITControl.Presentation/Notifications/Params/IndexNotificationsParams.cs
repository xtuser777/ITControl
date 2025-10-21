using ITControl.Application.Notifications.Params;
using ITControl.Communication.Notifications.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Notifications.Params;

public record IndexNotificationsParams
{
    [FromQuery]
    public FindManyNotificationsRequest FindManyRequest { get; init; } = new();
    
    [FromHeader]
    public OrderByNotificationsRequest OrderByRequest { get; init; } = new();

    public static implicit operator FindManyNotificationsServiceParams(
        IndexNotificationsParams param)
        => new()
        {
            FindManyParams = param.FindManyRequest,
            OrderByParams = param.OrderByRequest,
            PaginationParams = param.FindManyRequest
        };

    public static implicit operator FindManyPaginationNotificationsServiceParams(
        IndexNotificationsParams param)
        => new()
        {
            CountParams = param.FindManyRequest,
            Page = param.FindManyRequest.Page,
            Size = param.FindManyRequest.Size,
        };
}