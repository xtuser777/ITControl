using ITControl.Application.Contracts.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Contracts.Params;

public record DeleteContractsParams
{
    [FromRoute]
    public Guid Id { get; set; }

    public static implicit operator DeleteContractsServiceParams(
        DeleteContractsParams create)
        => new()
        {
            Id = create.Id,
        };
}
