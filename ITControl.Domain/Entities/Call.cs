using ITControl.Domain.Enums;
using ITControl.Domain.Validation;

namespace ITControl.Domain.Entities;

public sealed class Call : Entity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public CallReason Reason { get; set; }
    public Guid CallStatusId { get; set; }
    public Guid UserId { get; set; }
    public Guid LocationId { get; set; }
    public Guid? SystemId { get; set; }
    public Guid? EquipmentId { get; set; }

    public CallStatus? CallStatus { get; set; }
    public User? User { get; set; }
    public Location? Location { get; set; }
    public System? System { get; set; }
    public Equipment? Equipment { get; set; }

    public Call(
        string title, 
        string description, 
        CallReason reason,
        Guid callStatusId,
        Guid userId, 
        Guid locationId, 
        Guid? systemId, 
        Guid? equipmentId)
    {
        
        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        Reason = reason;
        CallStatusId = callStatusId;
        UserId = userId;
        LocationId = locationId;
        SystemId = systemId;
        EquipmentId = equipmentId;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }
}