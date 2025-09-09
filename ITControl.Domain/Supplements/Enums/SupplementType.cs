using ITControl.Domain.Shared.Attributes;
using ITControl.Domain.Shared.DisplayValues;

namespace ITControl.Domain.Supplements.Enums;

public enum SupplementType
{
    [DisplayValue(typeof(SupplementsTypes), nameof(SupplementsTypes.Tonner))]
    Tonner = 1,
    [DisplayValue(typeof(SupplementsTypes), nameof(SupplementsTypes.ImageDrum))]
    ImageDrum = 2,
}
