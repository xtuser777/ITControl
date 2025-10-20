using ITControl.Domain.Calls.Enums;
using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Calls.Params;

public record FindManyCallsRepositoryParams : FindManyRepositoryParams
{
    public string? Title { get; set; } = null;
    public string? Description { get; set; } = null;
    public CallReason? Reason { get; set; } = null;
    public Enums.CallStatus? Status { get; set; } = null;
    public Guid? UserId { get; set; } = null;
}
