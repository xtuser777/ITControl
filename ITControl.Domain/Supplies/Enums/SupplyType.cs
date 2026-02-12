using ITControl.Domain.Shared.Attributes;
using ITControl.Domain.Shared.DisplayValues;

namespace ITControl.Domain.Supplies.Enums;

public enum SupplyType
{
    [DisplayValue(typeof(SuppliesTypes), nameof(SuppliesTypes.Tonner))]
    Tonner = 1,
    [DisplayValue(typeof(SuppliesTypes), nameof(SuppliesTypes.ImageDrum))]
    ImageDrum = 2,
}
