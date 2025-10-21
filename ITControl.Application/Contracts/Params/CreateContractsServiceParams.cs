using ITControl.Communication.Contracts.Requests;
using ITControl.Domain.Contracts.Params;

namespace ITControl.Application.Contracts.Params;

public record CreateContractsServiceParams
{
    public ContractParams Params { get; set; } = new();
    public IEnumerable<CreateContractsContactsRequest> ContactsRequest { get; set; } = [];
}
