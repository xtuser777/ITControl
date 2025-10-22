using ITControl.Application.SupplementsMovements.Params;
using ITControl.Domain.SupplementsMovements.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.SupplementsMovements.Params;

public record ShowSupplementsMovementsParams
{
    [FromRoute]
    public Guid Id { get; set; }
    [FromQuery]
    public bool? IncludeSupplement { get; init; }
    [FromQuery]
    public bool? IncludeUser { get; init; }
    [FromQuery]
    public bool? IncludeUnit { get; init; }
    [FromQuery]
    public bool? IncludeDepartment { get; init; }
    [FromQuery]
    public bool? IncludeDivision { get; init; }

    public static implicit operator FindOneSupplementsMovementsServiceParams(
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