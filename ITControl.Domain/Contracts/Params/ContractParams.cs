namespace ITControl.Domain.Contracts.Params;

public record ContractParams
{
    public string ObjectName { get; set; } = string.Empty;
    public DateOnly StartedAt { get; set; }
    public DateOnly? EndedAt { get; set; } = null;
}
