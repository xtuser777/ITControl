using ITControl.Domain.Contracts.Entities;
using ITControl.Domain.Shared.Params2;

namespace ITControl.Domain.Contracts.Params;

public record UpdateContractParams : UpdateEntityParams
{
    public string? ObjectName { get; init; }
    public DateOnly? StartedAt { get; init; }
    public DateOnly? EndedAt { get; init; }
    public IEnumerable<ContractContact> ContractContacts { get; set; } = [];
}
