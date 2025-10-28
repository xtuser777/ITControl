using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Contracts.Params;

public record FindManyContractsParams : FindManyParams
{
    public string? ObjectName { get; set; } = null;
    public DateOnly? StartedAt { get; set; } = null;
    public DateOnly? EndedAt { get; set; } = null;
}
