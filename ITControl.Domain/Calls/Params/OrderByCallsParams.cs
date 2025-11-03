using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Calls.Params;

public record OrderByCallsParams : OrderByParams
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Reason { get; set; }
    public string? Status { get; set; }
    public string? User { get; set; }
}
