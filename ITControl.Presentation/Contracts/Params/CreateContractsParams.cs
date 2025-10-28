using ITControl.Application.Shared.Params;
using ITControl.Presentation.Contracts.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Contracts.Params;

public record CreateContractsParams
{
    [FromBody]
    public CreateContractsRequest CreateRequest { get; set; } = new();

    public static implicit operator CreateServiceParams(
        CreateContractsParams create)
        => new()
        {
            Params = create.CreateRequest,
        };
}
