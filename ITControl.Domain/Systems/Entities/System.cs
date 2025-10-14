using ITControl.Domain.Contracts.Entities;
using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Systems.Params;

namespace ITControl.Domain.Systems.Entities;

public class System : Entity
{
    public string Name { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;
    public DateOnly ImplementedAt { get; set; }
    public DateOnly? EndedAt { get; set; }
    public bool Own { get; set; }
    public Guid? ContractId { get; set; }

    public Contract? Contract { get; set; }

    public System()
    {
    }

    public System(SystemParams @params)
    {
        Id = Guid.NewGuid();
        Name = @params.Name;
        Version = @params.Version;
        ImplementedAt = @params.ImplementedAt;
        EndedAt = @params.EndedAt;
        Own = @params.Own;
        ContractId = @params.ContractId;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public void Update(UpdateSystemParams @params)
    {
        Name = @params.Name  ?? Name;
        Version = @params.Version ?? Version;
        ImplementedAt = @params.ImplementedAt ?? ImplementedAt;
        EndedAt = @params.EndedAt ?? EndedAt;
        Own = @params.Own ?? Own;
        ContractId = @params.ContractId ?? ContractId;
        UpdatedAt = DateTime.Now;
    }
}