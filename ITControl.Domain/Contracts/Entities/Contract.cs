using ITControl.Domain.Contracts.Params;
using ITControl.Domain.Shared.Entities;

namespace ITControl.Domain.Contracts.Entities;

public sealed class Contract : Entity
{
    public Contract()
    {
    }

    public Contract(ContractParams @params)
    {
        Id = Guid.NewGuid();
        ObjectName = @params.ObjectName;
        StartedAt = @params.StartedAt;
        EndedAt = @params.EndedAt;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public string ObjectName { get; set; } = string.Empty;
    public DateOnly StartedAt { get; set; }
    public DateOnly? EndedAt { get; set; }
    public IEnumerable<ContractContact>? ContractContacts { get; set; }

    public void Update(UpdateContractParams @params)
    {
        ObjectName = @params.ObjectName ?? ObjectName;
        StartedAt = @params.StartedAt ?? StartedAt;
        EndedAt = @params.EndedAt ?? EndedAt;
        UpdatedAt = DateTime.Now;
    }
}