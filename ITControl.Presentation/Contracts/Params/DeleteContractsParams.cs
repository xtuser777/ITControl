using ITControl.Application.Shared.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Contracts.Params;

public record DeleteContractsParams
{
    [FromRoute]
    public Guid Id { get; set; }

    public static implicit operator DeleteServiceParams(
        DeleteContractsParams create)
        => new()
        {
            Id = create.Id,
        };
}
