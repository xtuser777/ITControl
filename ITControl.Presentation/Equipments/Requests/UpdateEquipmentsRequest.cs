using System.ComponentModel.DataAnnotations;
using ITControl.Presentation.Shared.Attributes;
using ITControl.Presentation.Shared.Resources;
using ITControl.Presentation.Shared.Utils;
using ITControl.Domain.Equipments.Entities;
using ITControl.Domain.Equipments.Enums;
using ITControl.Domain.Equipments.Interfaces;
using ITControl.Domain.Equipments.Params;
using ITControl.Domain.Shared.Messages;

namespace ITControl.Presentation.Equipments.Requests;

public record UpdateEquipmentsRequest
{
    [StringMinLength(1)]
    [StringMaxLength(100)]
    [Display(Name = nameof(Name), ResourceType = typeof(DisplayNames))]
    public string? Name { get; set; }

    [StringMinLength(1)]
    [StringMaxLength(255)]
    [Display(Name = nameof(Description), ResourceType = typeof(DisplayNames))]
    public string? Description { get; set; }

    [StringMinLength(15)]
    [StringMaxLength(15)]
    [UniqueField<Equipment>(
        typeof(IEquipmentsRepository), 
        typeof(ExclusiveEquipmentsParams))]
    [Display(Name = nameof(Ip), ResourceType = typeof(DisplayNames))]
    public string? Ip { get; set; }

    [StringMinLength(17)]
    [StringMaxLength(17)]
    [UniqueField<Equipment>(
        typeof(IEquipmentsRepository), 
        typeof(ExclusiveEquipmentsParams))]
    [Display(Name = nameof(Mac), ResourceType = typeof(DisplayNames))]
    public string? Mac { get; set; }

    [StringMinLength(3)]
    [StringMaxLength(50)]
    [UniqueField<Equipment>(
        typeof(IEquipmentsRepository), 
        typeof(ExclusiveEquipmentsParams))]
    [Display(Name = nameof(Tag), ResourceType = typeof(DisplayNames))]
    public string? Tag { get; set; }

    [EnumValue(typeof(EquipmentType))]
    [Display(Name = nameof(Tag), ResourceType = typeof(DisplayNames))]
    public string? Type { get; set; }

    [BoolValue]
    [CustomValidation(typeof(UpdateEquipmentsRequest), nameof(ValidateRented))]
    [Display(Name = nameof(Rented), ResourceType = typeof(DisplayNames))]
    public bool? Rented { get; set; }

    [GuidValue]
    [CustomValidation(typeof(UpdateEquipmentsRequest), nameof(ValidateContractId))]
    [ContractConnection]
    [Display(Name = nameof(ContractId), ResourceType = typeof(DisplayNames))]
    public Guid? ContractId { get; set; }

    public static ValidationResult? ValidateRented(
        bool? x, ValidationContext context)
    {
        if (x == null)
            return ValidationResult.Success;
        var contractIdProperty = context.ObjectType.GetProperty(nameof(ContractId));
        if (contractIdProperty == null)
            return new ValidationResult(string.Empty);
        var contractIdValue = (Guid?)contractIdProperty.GetValue(context.ObjectInstance);
        if (!x.Value && contractIdValue != null)
            return new ValidationResult(string.Format(Errors.REQUIRED, context.DisplayName));
        return ValidationResult.Success;
    }

    public static ValidationResult? ValidateContractId(
        Guid? x, ValidationContext context)
    {
        var rentedProperty = context.ObjectType.GetProperty(nameof(Rented));
        if (rentedProperty == null)
            return ValidationResult.Success;
        var rentedValue = 
            (bool)(rentedProperty.
            GetValue(context.ObjectInstance) ?? throw new NullReferenceException());
        if (rentedValue && x == null)
            return new ValidationResult(
                string.Format(Errors.REQUIRED, context.DisplayName));
        return ValidationResult.Success;
    }

    public static implicit operator UpdateEquipmentParams(
        UpdateEquipmentsRequest request) => new()
    {
        Name = request.Name,
        Description = request.Description,
        Type = Parser.ToEnumOptional<EquipmentType>(request.Type),
        Ip = request.Ip,
        Mac = request.Mac,
        Tag = request.Tag,
        Rented = request.Rented,
        ContractId = request.ContractId
    };
}