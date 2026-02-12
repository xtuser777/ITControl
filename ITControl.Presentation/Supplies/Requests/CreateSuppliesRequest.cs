using System.ComponentModel.DataAnnotations;
using ITControl.Domain.Supplies.Enums;
using ITControl.Domain.Supplies.Props;
using ITControl.Presentation.Shared.Attributes;
using ITControl.Presentation.Shared.Resources;
using ITControl.Presentation.Shared.Utils;

namespace ITControl.Presentation.Supplies.Requests;

public class CreateSuppliesRequest
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
    [EnumValue(typeof(SupplyType))]
    [Display(Name = nameof(Type), ResourceType = typeof(DisplayNames))]
    public string Type { get; set; } = null!;

    [RequiredField]
    [IntegerPositiveValue]
    [Display(Name = nameof(Stock), ResourceType = typeof(DisplayNames))]
    public int Stock { get; set; }

    public static implicit operator SupplyProps(
        CreateSuppliesRequest request)
        => new()
        {
            Brand = request.Brand,
            Model = request.Model,
            Type = Parser.ToEnum<SupplyType>(request.Type),
            QuantityInStock = request.Stock
        };
}
