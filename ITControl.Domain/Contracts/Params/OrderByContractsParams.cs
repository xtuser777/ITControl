using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Contracts.Params;

public record OrderByContractsParams : OrderByParams
{
    public string? Enterprise { get; init; }
    public string? ObjectName { get; init; }
    public string? StartedAt { get; init; }
    public string? EndedAt { get; init; }
}
