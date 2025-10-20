using ITControl.Domain.Calls.Enums;
using ITControl.Domain.Calls.Params;
using ITControl.Domain.Equipments.Entities;
using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Users.Entities;

namespace ITControl.Domain.Calls.Entities;

public sealed class Call : Entity
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public CallReason Reason { get; set; }
    public Guid CallStatusId { get; set; }
    public Guid UserId { get; set; }
    public Guid? SystemId { get; set; }
    public Guid? EquipmentId { get; set; }

    public CallStatus? CallStatus { get; set; }
    public User? User { get; set; }
    public Systems.Entities.System? System { get; set; }
    public Equipment? Equipment { get; set; }

    public Call()
    {
    }

    public Call(CallParams callParams)
    {
        
        Id = Guid.NewGuid();
        Title = callParams.Title;
        Description = callParams.Description;
        Reason = callParams.Reason;
        CallStatusId = Guid.Empty;
        UserId = callParams.UserId;
        SystemId = callParams.SystemId;
        EquipmentId = callParams.EquipmentId;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }
}