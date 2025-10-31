using ITControl.Domain.Contracts.Entities;
using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Contracts.Params;

public record ContractParams : EntityParams
{
    public string Enterprise { get; set; } = string.Empty;
    public string ObjectName { get; set; } = string.Empty;
    public DateOnly StartedAt { get; set; }
    public DateOnly? EndedAt { get; set; }
    public IEnumerable<ContractContact> ContractContacts { get; set; } = [];
}
