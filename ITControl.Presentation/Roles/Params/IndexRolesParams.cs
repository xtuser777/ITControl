using ITControl.Application.Shared.Params;
using ITControl.Domain.Roles.Params;
using ITControl.Domain.Shared.Params;
using ITControl.Domain.Shared.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Roles.Params;

public record IndexRolesParams : PaginationParams
{
    public string? Name { get; set; }
    public string? Active { get; set; }
    
    [FromHeader(Name = "X-Order-By-Name")]
    public string? OrderByName { get; init; }
    [FromHeader(Name = "X-Order-By-Active")]
    public string? OrderByActive { get; init; }

    public static implicit operator OrderByRolesParams(
        IndexRolesParams request) => new()
    {
        Name = request.OrderByName,
        Active = request.OrderByActive
    };

    public static implicit operator FindManyRolesParams(
        IndexRolesParams request) => new()
    {
        Name = request.Name,
        Active = Parser.ToBoolOptional(request.Active)
    };

    public static implicit operator CountRolesParams(
        IndexRolesParams request) => new()
    {
        Name = request.Name,
        Active = Parser.ToBoolOptional(request.Active)
    };

    public static implicit operator FindManyServiceParams(
        IndexRolesParams param)
        => new()
        {
            FindManyProps = param,
            OrderByParams = param,
            PaginationParams = param
        };

    public static implicit operator FindManyPaginationServiceParams(
        IndexRolesParams param)
        => new()
        {
            CountProps = param,
            PaginationParams = param
        };
}