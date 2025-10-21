using ITControl.Application.Contracts.Params;
using ITControl.Communication.Contracts.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Contracts.Params;

public record CreateContractsParams
{
    [FromBody]
    public CreateContractsRequest CreateRequest { get; set; } = new();

    public static implicit operator CreateContractsServiceParams(
        CreateContractsParams create)
        => new()
        {
            Params = create.CreateRequest,
            ContactsRequest = create.CreateRequest.Contacts,
        };
}
