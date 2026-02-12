using ITControl.Application.Shared.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Supplies.Params;

public record DeleteSuppliesParams
{
    [FromRoute]
    public Guid Id { get; set; }

    public static implicit operator DeleteServiceParams(
        DeleteSuppliesParams param)
        => new()
        {
            Id = param.Id
        };
}