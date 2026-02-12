using ITControl.Domain.Supplies.Enums;
using ITControl.Domain.Supplies.Props;
using ITControl.Presentation.Shared.Attributes;
using ITControl.Presentation.Shared.Resources;
using ITControl.Presentation.Shared.Utils;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Presentation.Supplies.Requests;

public class UpdateSuppliesRequest
{
    [StringMinLength(1)]
    [StringMaxLength(100)]
    [Display(Name = nameof(Brand), ResourceType = typeof(DisplayNames))]
    public string? Brand { get; set; } = null!;

    [StringMinLength(1)]
    [StringMaxLength(100)]
    [Display(Name = nameof(Model), ResourceType = typeof(DisplayNames))]
    public string? Model { get; set; } = null!;

    [Display(Name = nameof(Type), ResourceType = typeof(DisplayNames))]
    [EnumValue(typeof(SupplyType))]
    public string? Type { get; set; } = null!;

    [IntegerPositiveValue]
    [Display(Name = nameof(Stock), ResourceType = typeof(DisplayNames))]
    public int? Stock { get; set; }

    public static implicit operator SupplyProps(
        UpdateSuppliesRequest request)
        => new()
        {
            Brand = request.Brand,
            Model = request.Model,
            Type = Parser.ToEnumOptional<SupplyType>(request.Type),
            QuantityInStock = request.Stock
        };
}
