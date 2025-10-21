using ITControl.Application.Contracts.Params;
using ITControl.Communication.Contracts.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Contracts.Params;

public record UpdateContractsParams
{
    [FromRoute]
    public Guid Id { get; set; }

    [FromBody]
    public UpdateContractsRequest UpdateRequest { get; set; } = new();

    public static implicit operator UpdateContractsServiceParams(
        UpdateContractsParams update)
        => new()
        {
            Id = update.Id,
            Params = update.UpdateRequest,
            ContactsRequest = update.UpdateRequest.Contacts,
        };
}
