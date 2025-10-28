using System.ComponentModel.DataAnnotations;
using ITControl.Presentation.Shared.Attributes;
using ITControl.Presentation.Shared.Resources;
using ITControl.Presentation.Shared.Utils;
using ITControl.Domain.Supplements.Enums;
using ITControl.Domain.Supplements.Params;

namespace ITControl.Presentation.Supplements.Requests;

public class CreateSupplementsRequest
{
    [RequiredField]
    [StringMaxLength(100)]
    [Display(Name = nameof(Brand), ResourceType = typeof(DisplayNames))]
    public string Brand { get; set; } = null!;

    [RequiredField]
    [StringMaxLength(100)]
    [Display(Name = nameof(Model), ResourceType = typeof(DisplayNames))]
    public string Model { get; set; } = null!;

    [RequiredField]
    [EnumValue(typeof(SupplementType))]
    [Display(Name = nameof(Type), ResourceType = typeof(DisplayNames))]
    public string Type { get; set; } = null!;

    [RequiredField]
    [IntegerPositiveValue]
    [Display(Name = nameof(Stock), ResourceType = typeof(DisplayNames))]
    public int Stock { get; set; }

    public static implicit operator SupplementParams(
        CreateSupplementsRequest request)
        => new()
        {
            Brand = request.Brand,
            Model = request.Model,
            Type = Parser.ToEnum<SupplementType>(request.Type),
            QuantityInStock = request.Stock
        };
}
