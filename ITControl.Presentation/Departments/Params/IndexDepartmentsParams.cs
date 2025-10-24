using ITControl.Application.Shared.Params;
using ITControl.Communication.Departments.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Departments.Params;

public record IndexDepartmentsParams
{
    [FromQuery]
    public FindManyDepartmentsRequest FindManyRequest { get; set; } = new();

    [FromHeader]
    public OrderByDepartmentsRequest OrderByRequest { get; set; } = new();

    public static implicit operator FindManyServiceParams(
        IndexDepartmentsParams paramsObj) =>
        new()
        {
            FindManyParams = paramsObj.FindManyRequest,
            OrderByParams = paramsObj.OrderByRequest,
            PaginationParams = paramsObj.FindManyRequest
        };

    public static implicit operator FindManyPaginationServiceParams(
        IndexDepartmentsParams paramsObj) =>
        new()
        {
            CountParams = paramsObj.FindManyRequest,
            PaginationParams = paramsObj.FindManyRequest
        };
}
