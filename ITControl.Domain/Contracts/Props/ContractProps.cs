using ITControl.Domain.Contracts.Entities;
using ITControl.Domain.Shared.Entities;

namespace ITControl.Domain.Contracts.Props;

public class ContractProps : Entity
{
    public string? Enterprise { get; set; }
    public string? ObjectName { get; set; }
    public DateOnly? StartedAt { get; set; }
    public DateOnly? EndedAt { get; set; }
    public IEnumerable<ContractContact>? ContractContacts { get; set; }
}