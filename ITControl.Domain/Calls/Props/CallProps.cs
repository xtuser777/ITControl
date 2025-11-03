using ITControl.Domain.Calls.Enums;
using ITControl.Domain.Equipments.Entities;
using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Users.Entities;
using CallStatus = ITControl.Domain.Calls.Entities.CallStatus;

namespace ITControl.Domain.Calls.Props;

public class CallProps : Entity
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public CallReason? Reason { get; set; }
    public Guid? CallStatusId { get; set; }
    public Guid? UserId { get; set; }
    public Guid? SystemId { get; set; }
    public Guid? EquipmentId { get; set; }
    public CallStatus? CallStatus { get; set; }
    public User? User { get; set; }
    public Systems.Entities.SystemEntity? System { get; set; }
    public Equipment? Equipment { get; set; }
}