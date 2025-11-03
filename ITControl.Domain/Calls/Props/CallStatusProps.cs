using ITControl.Domain.Shared.Entities;

namespace ITControl.Domain.Calls.Props;

public class CallStatusProps : Entity
{
    public Enums.CallStatus? Status { get; set; }
    public string? Description { get; set; }
}