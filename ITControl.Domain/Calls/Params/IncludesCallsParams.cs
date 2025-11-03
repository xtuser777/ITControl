using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Calls.Params;

public record IncludesCallsParams : IncludesParams
{
    public bool? User { get; set; }
    public bool? Equipment { get; set; }
    public bool? System { get; set; }
}
