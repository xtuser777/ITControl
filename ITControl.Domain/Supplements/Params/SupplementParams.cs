using ITControl.Domain.Supplements.Enums;

namespace ITControl.Domain.Supplements.Params;

public record SupplementParams
{
    public string Brand { get; set; } = null!;
    public string Model { get; set; } = null!;
    public SupplementType Type { get; set; }
    public int QuantityInStock { get; set; }
}