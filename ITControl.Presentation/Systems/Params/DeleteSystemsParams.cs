using ITControl.Application.Systems.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Systems.Params;

public record DeleteSystemsParams
{
    [FromRoute] public Guid Id { get; set; }

    public static implicit operator DeleteSystemsServiceParams(
        DeleteSystemsParams parameters)
        => new()
        {
            Id = parameters.Id,
        };
}