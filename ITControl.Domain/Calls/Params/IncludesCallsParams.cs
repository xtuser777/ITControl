namespace ITControl.Domain.Calls.Params;

public record IncludesCallsParams
{
    public bool? User { get; set; } = null;
    public bool? Equipment { get; set; } = null;
    public bool? System { get; set; } = null;
}
