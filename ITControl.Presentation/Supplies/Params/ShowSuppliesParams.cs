using ITControl.Application.Shared.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Supplies.Params;

public record ShowSuppliesParams
{
    [FromRoute]
    public Guid Id { get; set; }

    public static implicit operator FindOneServiceParams(
        ShowSuppliesParams @params)
        => new()
        {
            Id = @params.Id,
        };
}