using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Contracts.Params;

public record FindManyContractsParams : FindManyParams
{
    public string? Enterprise { get; init; }
    public string? ObjectName { get; set; }
    public DateOnly? StartedAt { get; set; }
    public DateOnly? EndedAt { get; set; }
}
