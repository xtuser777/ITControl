using ITControl.Domain.Shared.Params2;

namespace ITControl.Domain.SupplementsMovements.Params;

public record IncludesSupplementsMovementsParams : IncludesParams
{
    public bool? Supplement { get; init; }
    public bool? User { get; init; }
    public bool? Unit { get; init; }
    public bool? Department { get; init; }
    public bool? Division { get; init; }
}