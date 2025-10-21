using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Contracts.Params;

public record FindManyContractsRepositoryParams : FindManyRepositoryParams
{
    public string? ObjectName { get; set; } = null;
    public DateOnly? StartedAt { get; set; } = null;
    public DateOnly? EndedAt { get; set; } = null;
}
