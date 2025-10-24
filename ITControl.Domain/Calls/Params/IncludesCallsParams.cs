using ITControl.Domain.Shared.Params2;

namespace ITControl.Domain.Calls.Params;

public record IncludesCallsParams : IncludesParams
{
    public bool? User { get; set; } = null;
    public bool? Equipment { get; set; } = null;
    public bool? System { get; set; } = null;
}
