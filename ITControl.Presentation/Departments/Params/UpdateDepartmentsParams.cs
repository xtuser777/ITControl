using ITControl.Application.Shared.Params;
using ITControl.Presentation.Departments.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Departments.Params;

public record UpdateDepartmentsParams
{
    [FromRoute]
    public Guid Id { get; set; }

    [FromBody]
    public UpdateDepartmentsRequest Request { get; set; } = null!;

    public static implicit operator UpdateServiceParams(
        UpdateDepartmentsParams parameters) =>
        new()
        {
            Id = parameters.Id,
            Props = parameters.Request
        };
}
