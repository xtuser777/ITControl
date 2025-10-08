using ITControl.Domain.Calls.Enums;

namespace ITControl.Domain.Calls.Params;

public class CountCallsRepositoryParams
{
    public Guid? Id { get; set; } = null;
    public string? Title { get; set; } = null;
    public string? Description { get; set; } = null;
    public CallReason? Reason { get; set; } = null;
    public Enums.CallStatus? Status { get; set; } = null;
    public Guid? UserId { get; set; } = null;
}