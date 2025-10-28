using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.SupplementsMovements.Params;

public record OrderBySupplementsMovementsParams : OrderByParams
{
    public string? Quantity { get; init; }
    public string? MovementDate { get; init; }
    public string? Observation { get; init; }
    public string? Supplement { get; init; }
    public string? User { get; init; }
    public string? Unit { get; init; }
    public string? Department { get; init; }
    public string? Division { get; init; }
}