namespace ITControl.Domain.Systems.Params;

public record FindManySystemsRepositoryParams
{
    public string? Name { get; set; } = null;
    public string? Version { get; set; } = null;
    public DateOnly? ImplementedAt { get; set; } = null;
    public DateOnly? EndedAt { get; set; } = null;
    public bool? Own { get; set; } = null;
    public Guid? ContractId { get; set; }
}
