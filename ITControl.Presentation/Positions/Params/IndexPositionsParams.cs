using ITControl.Application.Positions.Params;
using ITControl.Communication.Positions.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Positions.Params;

public record IndexPositionsParams
{
    [FromQuery]
    public FindManyPositionsRequest FindManyRequest { get; set; } = new();
    [FromHeader]
    public OrderByPositionsRequest OrderByRequest { get; set; } = new();

    public static implicit operator FindManyPositionsServiceParams(
        IndexPositionsParams indexParams) =>
        new()
        {
            FindManyParams = indexParams.FindManyRequest,
            OrderByParams = indexParams.OrderByRequest,
            PaginationParams = indexParams.FindManyRequest
        };

    public static implicit operator FindManyPaginationPositionsServiceParams(
        IndexPositionsParams indexParams) =>
        new()
        {
            CountParams = indexParams.FindManyRequest,
            Page = indexParams.FindManyRequest.Page,
            Size = indexParams.FindManyRequest.Size
        };
}
