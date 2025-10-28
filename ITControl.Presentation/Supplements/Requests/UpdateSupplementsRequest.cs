﻿using System.ComponentModel.DataAnnotations;
using ITControl.Presentation.Shared.Attributes;
using ITControl.Presentation.Shared.Resources;
using ITControl.Presentation.Shared.Utils;
using ITControl.Domain.Supplements.Enums;
using ITControl.Domain.Supplements.Params;

namespace ITControl.Presentation.Supplements.Requests;

public class UpdateSupplementsRequest
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
    [EnumValue(typeof(SupplementType))]
    public string? Type { get; set; } = null!;

    [IntegerPositiveValue]
    [Display(Name = nameof(Stock), ResourceType = typeof(DisplayNames))]
    public int? Stock { get; set; }

    public static implicit operator UpdateSupplementParams(
        UpdateSupplementsRequest request)
        => new()
        {
            Brand = request.Brand,
            Model = request.Model,
            Type = Parser.ToEnumOptional<SupplementType>(request.Type),
            QuantityInStock = request.Stock
        };
}
