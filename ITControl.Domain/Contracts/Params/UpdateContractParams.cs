namespace ITControl.Domain.Contracts.Params;

public record UpdateContractParams
{
    public string? ObjectName { get; set; } = null;
    public DateOnly? StartedAt { get; set; } = null;
    public DateOnly? EndedAt { get; set; } = null;
}
