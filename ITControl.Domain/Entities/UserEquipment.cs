namespace ITControl.Domain.Entities;

public sealed class UserEquipment : Entity
{
    public UserEquipment(
        Guid userId, 
        Guid equipmentId, 
        DateOnly startedAt, 
        DateOnly? endedAt)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        EquipmentId = equipmentId;
        StartedAt = startedAt;
        EndedAt = endedAt;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public Guid UserId { get; set; }
    public Guid EquipmentId { get; set; }
    public DateOnly StartedAt { get; set; }
    public DateOnly? EndedAt { get; set; }

    public User? User { get; set; }
    public Equipment? Equipment { get; set; }

    public void Update(
        Guid? userId = null, 
        Guid? equipmentId = null, 
        DateOnly? startedAt = null, 
        DateOnly? endedAt = null)
    {
        UserId = userId ?? UserId;
        EquipmentId = equipmentId ?? EquipmentId;
        StartedAt = startedAt ?? StartedAt;
        EndedAt = endedAt ?? EndedAt;
        UpdatedAt = DateTime.Now;
    }
}