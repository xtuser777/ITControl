using ITControl.Application.Shared.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Units.Params;

public record DeleteUnitsParams
{
    [FromRoute] public Guid Id { get; set; }

    public static implicit operator DeleteServiceParams(
        DeleteUnitsParams parameters)
        => new()
        {
            Id = parameters.Id,
        };
}