using ITControl.Domain.Shared.Params2;

namespace ITControl.Domain.Systems.Params;

public record IncludesSystemsParams : IncludesParams
{
    public bool? Contract { get; set; }
}