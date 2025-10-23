namespace ITControl.Domain.Systems.Params;

public record SystemParams
{
    public string Name { get; init; } = string.Empty;
    public string Version { get; init; } = string.Empty;
    public DateOnly ImplementedAt { get; init; }
    public DateOnly? EndedAt { get; init; }
    public bool Own { get; init; }
    public Guid? ContractId { get; init; }
}
