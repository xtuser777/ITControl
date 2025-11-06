using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Calls.Params;

public record IncludesCallsParams : IncludesParams
{
    public IncludesCallsUserParams? User { get; set; }
    public bool? Equipment { get; set; }
    public bool? System { get; set; }
}

public record IncludesCallsUserParams
{
    public bool? Unit { get; set; }
    public bool? Position { get; set; }
    public bool? Department { get; set; }
    public bool? Division { get; set; }
}
