using ITControl.Domain.Calls.Enums;

namespace ITControl.Domain.Calls.Params;

public record CallParams
{
    public string? Title { get; init; }
    public string? Description { get; init; }
    public CallReason Reason { get; set; }
    public Guid? UserId { get; init; }
    public Guid? SystemId { get; init; }
    public Guid? EquipmentId { get; init; }
}
