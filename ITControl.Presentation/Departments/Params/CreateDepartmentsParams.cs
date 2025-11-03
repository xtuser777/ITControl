using ITControl.Application.Shared.Params;
using ITControl.Presentation.Departments.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Departments.Params;

public record CreateDepartmentsParams
{
    [FromBody]
    public CreateDepartmentsRequest Request { get; set; } = null!;

    public static implicit operator CreateServiceParams(
        CreateDepartmentsParams paramsModel) =>
        new()
        {
            Props = paramsModel.Request
        };
}
