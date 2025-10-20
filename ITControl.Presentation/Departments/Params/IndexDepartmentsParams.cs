using ITControl.Application.Departments.Params;
using ITControl.Communication.Departments.Requests;

namespace ITControl.Presentation.Departments.Params;

public record IndexDepartmentsParams
{
    public FindManyDepartmentsRequest FindManyRequest { get; set; } = null!;
    public OrderByDepartmentsRequest OrderByRequest { get; set; } = null!;

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
