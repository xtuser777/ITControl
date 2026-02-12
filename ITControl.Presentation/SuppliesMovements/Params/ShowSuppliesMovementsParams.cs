using ITControl.Application.Shared.Params;
using ITControl.Domain.SuppliesMovements.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.SuppliesMovements.Params;

public record ShowSuppliesMovementsParams
{
    [FromRoute] public Guid Id { get; set; }
    [FromQuery] public bool? IncludeSupply { get; init; } = true;
    [FromQuery] public bool? IncludeUser { get; init; } = true;
    [FromQuery] public bool? IncludeUnit { get; init; } = true;
    [FromQuery] public bool? IncludeDepartment { get; init; } = true;
    [FromQuery] public bool? IncludeDivision { get; init; } = true;

    public static implicit operator FindOneServiceParams(
        ShowSuppliesMovementsParams param)
        => new()
        {
            Id = param.Id,
            Includes = new IncludesSuppliesMovementsParams
            {
                Supply = param.IncludeSupply,
                User = param.IncludeUser,
                Unit = param.IncludeUnit,
                Department = param.IncludeDepartment,
                Division = param.IncludeDivision
            }
        };
}