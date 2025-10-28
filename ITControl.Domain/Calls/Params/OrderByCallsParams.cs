using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Calls.Params;

public record OrderByCallsParams : OrderByParams
{
    public string? Title { get; set; } = null;
    public string? Description { get; set; } = null;
    public string? Reason { get; set; } = null;
    public string? Status { get; set; } = null;
    public string? User { get; set; } = null;
}
