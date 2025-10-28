using ITControl.Domain.Shared.Params;
using ITControl.Domain.Supplements.Enums;

namespace ITControl.Domain.Supplements.Params;

public record UpdateSupplementParams : UpdateEntityParams
{
    public string? Brand { get; init; }
    public string? Model { get; init; }
    public SupplementType? Type { get; init; }
    public int? QuantityInStock { get; init; }
}