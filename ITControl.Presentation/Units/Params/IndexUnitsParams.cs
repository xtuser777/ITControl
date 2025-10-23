using ITControl.Application.Shared.Params;
using ITControl.Communication.Units.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Units.Params;

public record IndexUnitsParams
{
    [FromQuery] public FindManyUnitsRequest FindManyUnitsRequest { get; set; } = new();
    [FromHeader] public OrderByUnitsRequest OrderByUnitsRequest { get; set; }  = new();

    public static implicit operator FindManyServiceParams(
        IndexUnitsParams parameters)
        => new()
        {
            FindManyParams = parameters.FindManyUnitsRequest,
            OrderByParams = parameters.OrderByUnitsRequest,
            PaginationParams = parameters.FindManyUnitsRequest,
        };

    public static implicit operator FindManyPaginationServiceParams(
        IndexUnitsParams parameters)
        => new()
        {
            CountParams = parameters.FindManyUnitsRequest,
            PaginationParams = parameters.FindManyUnitsRequest,
        };
}