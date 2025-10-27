using ITControl.Application.Shared.Params;
using ITControl.Domain.SupplementsMovements.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.SupplementsMovements.Params;

public record ShowSupplementsMovementsParams
{
    [FromRoute] public Guid Id { get; set; }
    [FromQuery] public bool? IncludeSupplement { get; init; } = true;
    [FromQuery] public bool? IncludeUser { get; init; } = true;
    [FromQuery] public bool? IncludeUnit { get; init; } = true;
    [FromQuery] public bool? IncludeDepartment { get; init; } = true;
    [FromQuery] public bool? IncludeDivision { get; init; } = true;

    public static implicit operator FindOneServiceParams(
        ShowSupplementsMovementsParams param)
        => new()
        {
            Id = param.Id,
            Includes = new IncludesSupplementsMovementsParams
            {
                Supplement = param.IncludeSupplement,
                User = param.IncludeUser,
                Unit = param.IncludeUnit,
                Department = param.IncludeDepartment,
                Division = param.IncludeDivision
            }
        };
}