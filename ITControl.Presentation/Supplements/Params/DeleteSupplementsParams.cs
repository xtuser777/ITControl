using ITControl.Application.Supplements.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Supplements.Params;

public record DeleteSupplementsParams
{
    [FromRoute]
    public Guid Id { get; set; }

    public static implicit operator DeleteSupplementsServiceParams(
        DeleteSupplementsParams param)
        => new()
        {
            Id = param.Id
        };
}