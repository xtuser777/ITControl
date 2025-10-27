using ITControl.Application.Shared.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Supplements.Params;

public record DeleteSupplementsParams
{
    [FromRoute]
    public Guid Id { get; set; }

    public static implicit operator DeleteServiceParams(
        DeleteSupplementsParams param)
        => new()
        {
            Id = param.Id
        };
}