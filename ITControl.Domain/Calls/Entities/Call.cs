using ITControl.Domain.Calls.Enums;
using ITControl.Domain.Equipments.Entities;
using ITControl.Domain.Locations.Entities;
using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Users.Entities;

namespace ITControl.Domain.Calls.Entities;

public sealed class Call : Entity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public CallReason Reason { get; set; }
    public Guid CallStatusId { get; set; }
    public Guid UserId { get; set; }
    public Guid? SystemId { get; set; }
    public Guid? EquipmentId { get; set; }

    public CallStatus? CallStatus { get; set; }
    public User? User { get; set; }
    public Location? Location { get; set; }
    public Systems.Entities.System? System { get; set; }
    public Equipment? Equipment { get; set; }

    public Call(
        string title, 
        string description, 
        CallReason reason,
        Guid callStatusId,
        Guid userId, 
        Guid? systemId, 
        Guid? equipmentId)
    {
        
        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        Reason = reason;
        CallStatusId = callStatusId;
        UserId = userId;
        SystemId = systemId;
        EquipmentId = equipmentId;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }
}