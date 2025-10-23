using ITControl.Application.Shared.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Units.Params;

public record ShowUnitsParams
{
    [FromRoute] public Guid Id { get; set; }

    public static implicit operator FindOneServiceParams(
        ShowUnitsParams parameters)
        => new()
        {
            Id = parameters.Id,
        };
}