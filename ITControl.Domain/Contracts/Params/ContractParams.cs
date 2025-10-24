using ITControl.Domain.Contracts.Entities;
using ITControl.Domain.Shared.Params2;

namespace ITControl.Domain.Contracts.Params;

public record ContractParams : EntityParams
{
    public string ObjectName { get; set; } = string.Empty;
    public DateOnly StartedAt { get; set; }
    public DateOnly? EndedAt { get; set; } = null;
    public IEnumerable<ContractContact> ContractContacts { get; set; } = [];
}
