using ITControl.Application.Shared.Params;
using ITControl.Presentation.Contracts.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Contracts.Params;

public record UpdateContractsParams
{
    [FromRoute]
    public Guid Id { get; set; }

    [FromBody]
    public UpdateContractsRequest UpdateRequest { get; set; } = new();

    public static implicit operator UpdateServiceParams(
        UpdateContractsParams update)
        => new()
        {
            Id = update.Id,
            Props = update.UpdateRequest,
        };
}
