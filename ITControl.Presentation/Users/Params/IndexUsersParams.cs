using ITControl.Application.Shared.Params;
using ITControl.Communication.Users.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Users.Params;

public record IndexUsersParams
{
    [FromQuery] public FindManyUsersRequest 
        FindManyUsersRequest { get; set; } = new();
    [FromHeader] public OrderByUsersRequest 
        OrderByUsersRequest { get; set; }  = new();

    public static implicit operator FindManyServiceParams(
        IndexUsersParams param)
        => new()
        {
            FindManyParams = param.FindManyUsersRequest,
            OrderByParams = param.OrderByUsersRequest,
            PaginationParams = param.FindManyUsersRequest,
        };

    public static implicit operator FindManyPaginationServiceParams(
        IndexUsersParams param)
        => new()
        {
            CountParams = param.FindManyUsersRequest,
            PaginationParams = param.FindManyUsersRequest,
        };
}