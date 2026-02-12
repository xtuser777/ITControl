using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.SuppliesMovements.Params;

public record IncludesSuppliesMovementsParams : IncludesParams
{
    public bool? Supply { get; init; }
    public bool? User { get; init; }
    public bool? Unit { get; init; }
    public bool? Department { get; init; }
    public bool? Division { get; init; }
}