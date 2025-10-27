using ITControl.Domain.Shared.Params2;

namespace ITControl.Domain.Systems.Params;

public record OrderBySystemsParams : OrderByParams
{
    public string? Name { get; set; }
    public string? Version { get; set; }
    public string? ImplementedAt { get; set; }
    public string? EndedAt { get; set; }
    public string? Own { get; set; }
}
