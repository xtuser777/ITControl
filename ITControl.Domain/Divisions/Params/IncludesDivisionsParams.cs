using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Divisions.Params;

public record IncludesDivisionsParams : IncludesParams
{
    public bool? Department { get; set; }
}