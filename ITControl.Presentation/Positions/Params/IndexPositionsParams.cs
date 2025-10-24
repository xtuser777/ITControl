using ITControl.Application.Shared.Params;
using ITControl.Domain.Positions.Params;
using ITControl.Domain.Shared.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Positions.Params;

public record IndexPositionsParams : PaginationParams
{
    public string? Name { get; set; } = null;
    
    [FromHeader(Name = "X-Order-By-Name")]
    public string? OrderByName { get; set; } = null;

    public static implicit operator FindManyPositionsParams(
        IndexPositionsParams indexParams)
        => new ()
        {
            Name = indexParams.Name,
        };

    public static implicit operator CountPositionsParams(
        IndexPositionsParams indexParams)
        => new ()
        {
            Name = indexParams.Name,
        };

    public static implicit operator OrderByPositionsParams(
        IndexPositionsParams indexParams)
        => new ()
        {
            Name = indexParams.OrderByName,
        };

    public static implicit operator FindManyServiceParams(
        IndexPositionsParams indexParams) =>
        new()
        {
            FindManyParams = indexParams,
            OrderByParams = indexParams,
            PaginationParams = indexParams
        };

    public static implicit operator FindManyPaginationServiceParams(
        IndexPositionsParams indexParams) =>
        new()
        {
            CountParams = (CountPositionsParams)indexParams,
            PaginationParams = indexParams
        };
}
