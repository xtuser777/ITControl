using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Contracts.Params;

public record OrderByContractsRepositoryParams : OrderByRepositoryParams
{
    public string? ObjectName { get; set; } = null;
    public string? StartedAt { get; set; } = null; // "asc" | "desc"
    public string? EndedAt { get; set; } = null; // "asc" | "desc"
}
