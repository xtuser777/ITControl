using ITControl.Application.Shared.Params;
using ITControl.Domain.Shared.Params;
using ITControl.Domain.Units.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Units.Params;

public record IndexUnitsParams : PaginationParams
{
    public string? Name { get; set; }
    
    
    [FromHeader(Name = "X-Order-By-Name")]
    public string? OrderByName { get; init; }

    public static implicit operator OrderByUnitsParams(
        IndexUnitsParams request) => new()
    {
        Name = request.OrderByName
    };

    public static implicit operator FindManyUnitsParams(
        IndexUnitsParams request) => new()
    {
        Name = request.Name
    };

    public static implicit operator CountUnitsParams(
        IndexUnitsParams request) => new()
    {
        Name = request.Name
    };

    public static implicit operator FindManyServiceParams(
        IndexUnitsParams parameters)
        => new()
        {
            FindManyProps = parameters,
            OrderByParams = parameters,
            PaginationParams = parameters,
        };

    public static implicit operator FindManyPaginationServiceParams(
        IndexUnitsParams parameters)
        => new()
        {
            CountProps = parameters,
            PaginationParams = parameters,
        };
}