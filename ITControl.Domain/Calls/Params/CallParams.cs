using ITControl.Domain.Calls.Enums;

namespace ITControl.Domain.Calls.Params;

public record CallParams
{
    public string Title { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public CallReason Reason { get; init; }
    public Guid CallStatusId { get; init; }
    public Guid UserId { get; init; }
    public Guid? SystemId { get; init; }
    public Guid? EquipmentId { get; init; }
}
