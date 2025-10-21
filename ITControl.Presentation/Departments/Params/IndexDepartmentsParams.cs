using ITControl.Application.Departments.Params;
using ITControl.Communication.Departments.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Departments.Params;

public record IndexDepartmentsParams
{
    [FromQuery]
    public FindManyDepartmentsRequest FindManyRequest { get; set; } = new();

    [FromHeader]
    public OrderByDepartmentsRequest OrderByRequest { get; set; } = new();

    public static implicit operator FindManyDepartmentsServiceParams(
        IndexDepartmentsParams paramsObj) =>
        new()
        {
            FindManyParams = paramsObj.FindManyRequest,
            OrderByParams = paramsObj.OrderByRequest,
            PaginationParams = paramsObj.FindManyRequest
        };

    public static implicit operator FindManyPaginationDepartmentsServiceParams(
        IndexDepartmentsParams paramsObj) =>
        new()
        {
            CountParams = paramsObj.FindManyRequest,
            Page = paramsObj.FindManyRequest.Page,
            Size = paramsObj.FindManyRequest.Size
        };
}
