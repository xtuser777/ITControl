using ITControl.Domain.Shared.Params2;
using ITControl.Domain.Supplements.Enums;

namespace ITControl.Domain.Supplements.Params;

public record SupplementParams : EntityParams
{
    public string Brand { get; init; } = null!;
    public string Model { get; init; } = null!;
    public SupplementType Type { get; init; }
    public int QuantityInStock { get; init; }
}