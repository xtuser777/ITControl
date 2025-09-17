using ITControl.Communication.Shared.Attributes;
using System.ComponentModel.DataAnnotations;
using ITControl.Domain.Equipments.Enums;
using ITControl.Communication.Shared.Resources;
using ITControl.Domain.Shared.Messages;

namespace ITControl.Communication.Equipments.Requests;

public class UpdateEquipmentsRequest
{
    [StringMaxLength(100)]
    [Display(Name = nameof(Name), ResourceType = typeof(DisplayNames))]
    public string? Name { get; set; }
    
    [StringMaxLength(255)]
    [Display(Name = nameof(Description), ResourceType = typeof(DisplayNames))]
    public string? Description { get; set; }

    [StringMaxLength(15)]
    [Display(Name = nameof(Ip), ResourceType = typeof(DisplayNames))]
    public string? Ip { get; set; }

    [StringMaxLength(17)]
    [Display(Name = nameof(Mac), ResourceType = typeof(DisplayNames))]
    public string? Mac { get; set; }

    [StringMaxLength(50)]
    [Display(Name = nameof(Tag), ResourceType = typeof(DisplayNames))]
    public string? Tag { get; set; }

    [CustomValidation(typeof(UpdateEquipmentsRequest), nameof(ValidateType))]
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

    public static ValidationResult? ValidateRented(bool? x, ValidationContext context)
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

    public static ValidationResult? ValidateContractId(Guid? x, ValidationContext context)
    {
        var rentedProperty = context.ObjectType.GetProperty(nameof(Rented));
        if (rentedProperty == null)
            return ValidationResult.Success;
        var rentedValue = (bool)(rentedProperty.GetValue(context.ObjectInstance) ?? throw new NullReferenceException());
        if (rentedValue && x == null)
            return new ValidationResult(string.Format(Errors.REQUIRED, context.DisplayName));
        return ValidationResult.Success;
    }

    public static ValidationResult? ValidateType(string? x, ValidationContext context)
    {
        if (x == null)
            return ValidationResult.Success;
        if (!Enum.TryParse(typeof(EquipmentType), x, out var _))
        {
            var types = string.Join(", ", Enum.GetNames(typeof(EquipmentType)));
            return new ValidationResult(string.Format(Errors.MustBeAOneOfTheseValues, context.DisplayName, types));
        }
        return ValidationResult.Success;
    }
}