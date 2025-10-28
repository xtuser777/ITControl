using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Systems.Params;

public record IncludesSystemsParams : IncludesParams
{
    public bool? Contract { get; set; }
}