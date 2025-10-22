using ITControl.Application.Supplements.Params;
using ITControl.Communication.Supplements.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Supplements.Params;

public record IndexSupplementsParams
{
    [FromQuery]
    public FindManySupplementsRequest 
        FindManySupplementsRequest { get; set; } = new();

    [FromHeader]
    public OrderBySupplementsRequest 
        OrderBySupplementsRequest { get; set; } = new();

    public static implicit operator FindManySupplementsServiceParams(
        IndexSupplementsParams @params)
        => new()
        {
            FindManyParams = @params.FindManySupplementsRequest,
            OrderByParams = @params.OrderBySupplementsRequest,
            PaginationParams = @params.FindManySupplementsRequest,
        };

    public static implicit operator FindManyPaginationSupplementsServiceParams(
        IndexSupplementsParams @params)
        => new()
        {
            CountParams = @params.FindManySupplementsRequest,
            Page = @params.FindManySupplementsRequest.Page,
            Size = @params.FindManySupplementsRequest.Size,
        };
}