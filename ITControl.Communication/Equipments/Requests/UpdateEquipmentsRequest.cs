using ITControl.Communication.Shared.Attributes;
using System.ComponentModel.DataAnnotations;
using ITControl.Domain.Equipments.Enums;

namespace ITControl.Communication.Equipments.Requests;

public class UpdateEquipmentsRequest
{
    [StringMaxLength(100)]
    [Display(Name = "nome")]
    public string? Name { get; set; }
    
    [StringMaxLength(255)]
    [Display(Name = "descri��o")]
    public string? Description { get; set; }

    [StringMaxLength(15)]
    [Display(Name = "endere�o IP")]
    public string? Ip { get; set; }

    [StringMaxLength(17)]
    [Display(Name = "endere�o MAC")]
    public string? Mac { get; set; }

    [StringMaxLength(50)]
    [Display(Name = "etiqueta")]
    public string? Tag { get; set; }

    [CustomValidation(typeof(UpdateEquipmentsRequest), nameof(ValidateType))]
    [Display(Name = "tipo")]
    public string? Type { get; set; }

    [BoolValue]
    [CustomValidation(typeof(UpdateEquipmentsRequest), nameof(ValidateRented))]
    [Display(Name = "alugado")]
    public bool? Rented { get; set; }

    [CustomValidation(typeof(UpdateEquipmentsRequest), nameof(ValidateContractId))]
    [GuidNullableConverter]
    [GuidValue]
    [Display(Name = "contrato")]
    public Guid? ContractId { get; set; }

    public static ValidationResult? ValidateRented(bool? x, ValidationContext context)
    {
        if (x == null)
            return ValidationResult.Success;
        var contractIdProperty = context.ObjectType.GetProperty("ContractId");
        if (contractIdProperty == null)
            return new ValidationResult("ContractId property not found.");
        var contractIdValue = (Guid?)contractIdProperty.GetValue(context.ObjectInstance);
        if (!x.Value && contractIdValue != null)
            return new ValidationResult($"O campo {context.DisplayName} deve ser marcado quando o contrato estiver presente.");
        return ValidationResult.Success;
    }

    public static ValidationResult? ValidateContractId(Guid? x, ValidationContext context)
    {
        var rentedProperty = context.ObjectType.GetProperty("Rented");
        if (rentedProperty == null)
            return ValidationResult.Success;
        var rentedValue = (bool)(rentedProperty.GetValue(context.ObjectInstance) ?? throw new NullReferenceException());
        if (rentedValue && x == null)
            return new ValidationResult($"O campo {context.DisplayName} � obrigat�rio quando o equipamento for alugado.");
        return ValidationResult.Success;
    }

    public static ValidationResult? ValidateType(string? x, ValidationContext context)
    {
        if (x == null)
            return ValidationResult.Success;
        if (!Enum.TryParse(typeof(EquipmentType), x, out var _))
        {
            var types = string.Join(", ", Enum.GetNames(typeof(EquipmentType)));
            return new ValidationResult($"O campo {context.DisplayName} deve possuir um dos sequintes valores: {types}.");
        }
        return ValidationResult.Success;
    }
}