using ITControl.Domain.Validation;

namespace ITControl.Domain.Entities;

public sealed class Contract : Entity
{
    public Contract(string objectName, DateOnly startedAt, DateOnly? endedAt)
    {
        Id = Guid.NewGuid();
        ObjectName = objectName;
        StartedAt = startedAt;
        EndedAt = endedAt;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public string ObjectName { get; set; }
    public DateOnly StartedAt { get; set; }
    public DateOnly? EndedAt { get; set; }
    public IEnumerable<ContractContact>? ContractContacts { get; set; }

    public void Update(
        string? objectName = null, DateOnly? startedAt = null, DateOnly? endedAt = null)
    {
        ObjectName = objectName ?? ObjectName;
        StartedAt = startedAt ?? StartedAt;
        EndedAt = endedAt ?? EndedAt;
        UpdatedAt = DateTime.Now;
    }
}