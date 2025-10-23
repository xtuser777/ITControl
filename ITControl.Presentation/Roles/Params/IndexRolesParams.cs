using ITControl.Application.Shared.Params;
using ITControl.Communication.Roles.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Roles.Params;

public record IndexRolesParams
{
    [FromQuery] public FindManyRolesRequest 
        FindManyRolesRequest { get; set; } = new();
    [FromHeader] public OrderByRolesRequest 
        OrderByRolesRequest { get; set; } = new();

    public static implicit operator FindManyServiceParams(
        IndexRolesParams param)
        => new()
        {
            FindManyParams = param.FindManyRolesRequest,
            OrderByParams = param.OrderByRolesRequest,
            PaginationParams = param.FindManyRolesRequest
        };

    public static implicit operator FindManyPaginationServiceParams(
        IndexRolesParams param)
        => new()
        {
            CountParams = param.FindManyRolesRequest,
            PaginationParams = param.FindManyRolesRequest
        };
}