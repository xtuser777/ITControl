using ITControl.Domain.Calls.Enums;
using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Calls.Params;

public record CallParams : EntityParams
{
    public string Title { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public CallReason Reason { get; init; }
    public Guid CallStatusId { get; init; }
    public Guid UserId { get; init; }
    public Guid? SystemId { get; init; }
    public Guid? EquipmentId { get; init; }
}
