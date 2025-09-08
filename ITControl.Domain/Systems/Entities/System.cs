using ITControl.Domain.Contracts.Entities;
using ITControl.Domain.Shared.Entities;

namespace ITControl.Domain.Systems.Entities;

public class System : Entity
{
    public System(
        string name,
        string version,
        DateOnly implementedAt,
        DateOnly? endedAt,
        bool own,
        Guid? contractId)
    {
        Id = Guid.NewGuid();
        Name = name;
        Version = version;
        ImplementedAt = implementedAt;
        EndedAt = endedAt;
        Own = own;
        ContractId = contractId;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public string Name { get; set; }
    public string Version { get; set; }
    public DateOnly ImplementedAt { get; set; }
    public DateOnly? EndedAt { get; set; }
    public bool Own { get; set; }
    public Guid? ContractId { get; set; }

    public void Update(
        string? name = null,
        string? version = null,
        DateOnly? implementedAt = null,
        DateOnly? endedAt = null,
        bool? own = null,
        Guid? contractId = null)
    {
        Name = name ?? Name;
        Version = version ?? Version;
        ImplementedAt = implementedAt ?? ImplementedAt;
        EndedAt = endedAt ?? EndedAt;
        Own = own ?? Own;
        ContractId = contractId ?? ContractId;
        UpdatedAt = DateTime.Now;
    }

    public Contract? Contract { get; set; }
}