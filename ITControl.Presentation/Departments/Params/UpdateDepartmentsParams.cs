using ITControl.Application.Departments.Params;
using ITControl.Communication.Departments.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Departments.Params;

public record UpdateDepartmentsParams
{
    [FromRoute]
    public Guid Id { get; set; }

    [FromBody]
    public UpdateDepartmentsRequest Request { get; set; } = null!;

    public static implicit operator UpdateDepartmentsServiceParams(
        UpdateDepartmentsParams params_) =>
        new()
        {
            Id = params_.Id,
            Params = params_.Request
        };
}
