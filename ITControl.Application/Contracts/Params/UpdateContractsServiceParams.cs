using ITControl.Communication.Contracts.Requests;
using ITControl.Domain.Contracts.Params;

namespace ITControl.Application.Contracts.Params;

public record UpdateContractsServiceParams
{
    public Guid Id { get; set; }
    public UpdateContractParams Params { get; set; } = new();
    public IEnumerable<CreateContractsContactsRequest> ContactsRequest { get; set; } = [];

    public static implicit operator FindOneContractsServiceParams(
        UpdateContractsServiceParams model)
        => new() { Id = model.Id };
}
