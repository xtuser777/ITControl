using ITControl.Application.Departments.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Departments.Params;

public record DeleteDepartmentsParams
{
    [FromRoute(Name = "id")]
    public Guid Id { get; init; }

    public static implicit operator DeleteDepartmentsServiceParams(
        DeleteDepartmentsParams paramsModel) =>
        new ()
        {
            Id = paramsModel.Id,
        };
}
