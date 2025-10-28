using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Systems.Params;

public record UpdateSystemParams : UpdateEntityParams
{
    public string? Name { get; init; }
    public string? Version { get; init; }
    public DateOnly? ImplementedAt { get; init; }
    public DateOnly? EndedAt { get; init; }
    public bool? Own { get; init; }
    public Guid? ContractId { get; init; }
}
