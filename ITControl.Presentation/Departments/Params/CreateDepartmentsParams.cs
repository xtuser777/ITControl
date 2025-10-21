using ITControl.Application.Departments.Params;
using ITControl.Communication.Departments.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Departments.Params;

public record CreateDepartmentsParams
{
    [FromBody]
    public CreateDepartmentsRequest Request { get; set; } = null!;

    public static implicit operator CreateDepartmentsServiceParams(
        CreateDepartmentsParams paramsModel) =>
        new()
        {
            Params = paramsModel.Request
        };
}
