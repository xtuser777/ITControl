using ITControl.Domain.Supplements.Enums;

namespace ITControl.Domain.Supplements.Params;

public record UpdateSupplementParams
{
    public string? Brand { get; set; } = null;
    public string? Model { get; set; } = null;
    public SupplementType? Type { get; set; } = null;
    public int? QuantityInStock { get; set; } = null;
}