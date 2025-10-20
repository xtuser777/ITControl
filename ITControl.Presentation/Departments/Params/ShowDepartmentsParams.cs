using ITControl.Application.Departments.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Departments.Params;

public record ShowDepartmentsParams
{
    [FromRoute]
    public Guid Id { get; set; }

    public static implicit operator FindOneDepartmentsServiceParams(
        ShowDepartmentsParams showParams) =>
        new ()
        {
            Id = showParams.Id,
        };
}
