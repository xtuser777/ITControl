using ITControl.Application.Shared.Params;
using ITControl.Domain.Divisions.Params;
using ITControl.Domain.Shared.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Divisions.Params;

public record IndexDivisionsParams : PaginationParams
{
    public string? Name { get; init; } = null;
    public Guid? DepartmentId { get; init; } = null;
    
    [FromHeader(Name = "X-Order-By-Name")]
    public string? OrderByName { get; init; } = null;
    
    [FromHeader(Name = "X-Order-By-Department")]
    public string? OrderByDepartment { get; init; } = null;

    public static implicit operator OrderByDivisionsParams(
        IndexDivisionsParams request)
        => new()
        {
            Name = request.OrderByName,
            Department = request.OrderByDepartment,
        };

    public static implicit operator FindManyDivisionsParams(
        IndexDivisionsParams request)
        => new()
        {
            Name = request.Name,
            DepartmentId = request.DepartmentId,
        };

    public static implicit operator CountDivisionsParams(
        IndexDivisionsParams request)
        => new()
        {
            Name = request.Name,
            DepartmentId = request.DepartmentId
        };

    public static implicit operator FindManyServiceParams(
        IndexDivisionsParams parameters)
        => new()
        {
            FindManyParams = parameters,
            OrderByParams = parameters,
            PaginationParams = parameters,
        };

    public static implicit operator FindManyPaginationServiceParams(
        IndexDivisionsParams parameters)
        => new()
        {
            CountParams = parameters,
            PaginationParams = parameters,
        };
}