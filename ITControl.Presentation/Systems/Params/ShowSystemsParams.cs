using ITControl.Application.Systems.Params;
using ITControl.Domain.Systems.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Systems.Params;

public record ShowSystemsParams
{
    [FromRoute] public Guid Id { get; set; }
    [FromQuery] public bool? IncludeContract { get; set; } = true;

    public static implicit operator FindOneSystemsServiceParams(
        ShowSystemsParams parameters)
        => new()
        {
            Id = parameters.Id,
            Includes = new IncludesSystemsParams
            {
                Contract = parameters.IncludeContract,
            }
        };
}