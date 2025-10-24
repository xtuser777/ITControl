using ITControl.Application.Shared.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Departments.Params;

public record ShowDepartmentsParams
{
    [FromRoute]
    public Guid Id { get; set; }

    public static implicit operator FindOneServiceParams(
        ShowDepartmentsParams showParams) =>
        new ()
        {
            Id = showParams.Id,
        };
}
