using ITControl.Application.Supplements.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Supplements.Params;

public record ShowSupplementsParams
{
    [FromRoute]
    public Guid Id { get; set; }

    public static implicit operator FindOneSupplementsServiceParams(
        ShowSupplementsParams @params)
        => new()
        {
            Id = @params.Id,
        };
}