using ITControl.Application.Systems.Params;
using ITControl.Communication.Systems.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Systems.Params;

public record IndexSystemsParams
{
    [FromQuery] public FindManySystemsRequest 
        FindManySystemsRequest { get; set; } = new();
    [FromHeader] public OrderBySystemsRequest 
        OrderBySystemsRequest { get; set; } = new();

    public static implicit operator FindManySystemsServiceParams(
        IndexSystemsParams parameters)
        => new()
        {
            FindManySystemsParams = parameters.FindManySystemsRequest,
            OrderBySystemsParams = parameters.OrderBySystemsRequest,
            PaginationParams = parameters.FindManySystemsRequest
        };

    public static implicit operator FindManyPaginationSystemsServiceParams(
        IndexSystemsParams parameters)
        => new()
        {
            CountSystemsRepositoryParams = parameters.FindManySystemsRequest,
            Page = parameters.FindManySystemsRequest.Page,
            Size = parameters.FindManySystemsRequest.Size,
        };
}