namespace ITControl.Domain.Contracts.Params;

public record OrderByContractsRepositoryParams
{
    public string? ObjectName { get; set; } = null;
    public string? StartedAt { get; set; } = null; // "asc" | "desc"
    public string? EndedAt { get; set; } = null; // "asc" | "desc"
}
