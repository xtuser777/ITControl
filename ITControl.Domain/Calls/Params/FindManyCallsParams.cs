using ITControl.Domain.Calls.Enums;
using ITControl.Domain.Shared.Params2;

namespace ITControl.Domain.Calls.Params;

public record FindManyCallsParams : FindManyParams
{
    public string? Title { get; set; } = null;
    public string? Description { get; set; } = null;
    public CallReason? Reason { get; set; } = null;
    public Enums.CallStatus? Status { get; set; } = null;
    public Guid? UserId { get; set; } = null;
}
