namespace ITControl.Domain.Systems.Params;

public record UpdateSystemParams
{
    public string? Name { get; init; } = null;
    public string? Version { get; init; } = null;
    public DateOnly? ImplementedAt { get; init; } = null;
    public DateOnly? EndedAt { get; init; } = null;
    public bool? Own { get; init; } = null;
    public Guid? ContractId { get; init; } = null;
}
