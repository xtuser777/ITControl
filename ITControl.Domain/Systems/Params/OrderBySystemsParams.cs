using ITControl.Domain.Shared.Params2;

namespace ITControl.Domain.Systems.Params;

public record OrderBySystemsParams : OrderByParams
{
    public string? Name { get; set; } = null;
    public string? Version { get; set; } = null;
    public string? ImplementedAt { get; set; } = null;
    public string? EndedAt { get; set; } = null;
    public string? Own { get; set; } = null;
}
