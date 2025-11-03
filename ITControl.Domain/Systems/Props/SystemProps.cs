using ITControl.Domain.Contracts.Entities;
using ITControl.Domain.Shared.Entities;

namespace ITControl.Domain.Systems.Props;

public class SystemProps : Entity
{
    public string? Name { get; set; }
    public string? Version { get; set; }
    public bool? Own { get; set; }
    public DateOnly? ImplementedAt { get; set; }
    public DateOnly? EndedAt { get; set; }
    public Guid? ContractId { get; set; }
    public Contract? Contract { get; set; }
}