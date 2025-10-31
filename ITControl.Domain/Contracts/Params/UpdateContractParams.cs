using ITControl.Domain.Contracts.Entities;
using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Contracts.Params;

public record UpdateContractParams : UpdateEntityParams
{
    public string? Enterprise { get; init; }
    public string? ObjectName { get; init; }
    public DateOnly? StartedAt { get; init; }
    public DateOnly? EndedAt { get; init; }
    public IEnumerable<ContractContact> ContractContacts { get; set; } = [];
}
