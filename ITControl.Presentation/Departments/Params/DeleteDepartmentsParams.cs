using ITControl.Application.Shared.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Departments.Params;

public record DeleteDepartmentsParams
{
    [FromRoute(Name = "id")]
    public Guid Id { get; init; }

    public static implicit operator DeleteServiceParams(
        DeleteDepartmentsParams paramsModel) =>
        new ()
        {
            Id = paramsModel.Id,
        };
}
