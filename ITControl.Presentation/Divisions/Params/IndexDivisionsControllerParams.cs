using ITControl.Application.Divisions.Params;
using ITControl.Communication.Divisions.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Divisions.Params;

public record IndexDivisionsControllerParams
{
    [FromQuery]
    public FindManyDivisionsRequest FindManyRequest { get; set; } = null!;
    [FromHeader]
    public OrderByDivisionsRequest OrderByRequest { get; set; } = null!;

    public static implicit operator FindManyDivisionsServiceParams(IndexDivisionsControllerParams param)
        => new()
        {
            FindManyParams = @param.FindManyRequest,
            OrderByParams = @param.OrderByRequest,
            PaginationParams = @param.FindManyRequest,
        };

    public static implicit operator FindManyPaginationDivisionsServiceParams(IndexDivisionsControllerParams param)
        => new()
        {
            CountParams = param.FindManyRequest,
            Page = param.FindManyRequest.Page,
            Size = param.FindManyRequest.Size,
        };
}