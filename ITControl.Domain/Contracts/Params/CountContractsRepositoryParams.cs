namespace ITControl.Domain.Contracts.Params;

public record CountContractsRepositoryParams
{
    public Guid? Id { get; set; } = null;
    public string? ObjectName { get; set; } = null;
    public DateOnly? StartedAt { get; set; } = null;
    public DateOnly? EndedAt { get; set; } = null;
}
