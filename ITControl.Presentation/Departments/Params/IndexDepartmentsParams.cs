using ITControl.Application.Shared.Params;
using ITControl.Domain.Departments.Params;
using ITControl.Domain.Shared.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Departments.Params;

public record IndexDepartmentsParams : PaginationParams
{
    public string? Alias { get; set; }
    public string? Name { get; set; }
    
    [FromHeader(Name = "X-Order-By-Alias")]
    public string? OrderByAlias { get; set; }
    
    [FromHeader(Name = "X-Order-By-Name")]
    public string? OrderByName { get; set; }

    public static implicit operator OrderByDepartmentsParams(
        IndexDepartmentsParams request)
    {
        return new OrderByDepartmentsParams
        {
            Alias = request.OrderByAlias,
            Name = request.OrderByName,
        };
    }

    public static implicit operator FindManyDepartmentsParams(
        IndexDepartmentsParams request)
    {
        return new FindManyDepartmentsParams
        {
            Alias = request.Alias,
            Name = request.Name,
        };
    }

    public static implicit operator CountDepartmentsParams(
        IndexDepartmentsParams request)
    {
        return new CountDepartmentsParams
        {
            Alias = request.Alias,
            Name = request.Name,
        };
    }

    public static implicit operator FindManyServiceParams(
        IndexDepartmentsParams paramsObj) =>
        new()
        {
            FindManyProps = paramsObj,
            OrderByParams = paramsObj,
            PaginationParams = paramsObj
        };

    public static implicit operator FindManyPaginationServiceParams(
        IndexDepartmentsParams paramsObj) =>
        new()
        {
            CountProps = paramsObj,
            PaginationParams = paramsObj
        };
}
