using ITControl.Communication.Shared.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Equipments.Requests;

public class CreateEquipmentsRequest
{
    [RequiredField]
    [StringMaxLength(100)]
    [Display(Name = "nome")]    
    public string Name { get; set; } = string.Empty;

    [RequiredField]
    [StringMaxLength(255)]
    [Display(Name = "descrição")]
    public string Description { get; set; } = string.Empty;

    [RequiredField]
    [StringMaxLength(15)]
    [Display(Name = "endereço IP")]
    public string Ip { get; set; } = string.Empty;

    [RequiredField]
    [StringMaxLength(17)]
    [Display(Name = "endereço MAC")]
    public string Mac { get; set; } = string.Empty;

    [RequiredField]
    [StringMaxLength(50)]
    [Display(Name = "etiqueta")]
    public string Tag { get; set; } = string.Empty;

    [RequiredField]
    [CustomValidation(typeof(CreateEquipmentsRequest), nameof(ValidateType))]
    [Display(Name = "tipo")]
    public string Type { get; set; } = string.Empty;

    [RequiredField]
    [BoolValue]
    [CustomValidation(typeof(CreateEquipmentsRequest), nameof(ValidateRented))]
    [Display(Name = "alugado")]
    public bool Rented { get; set; }

    [GuidNullableConverter]
    [GuidValue]
    [CustomValidation(typeof(CreateEquipmentsRequest), nameof(ValidateContractId))]
    [Display(Name = "contrato")]
    public Guid? ContractId { get; set; }

    public static ValidationResult? ValidateRented(bool x, ValidationContext context)
    {
        var contractIdProperty = context.ObjectType.GetProperty("ContractId");
        if (contractIdProperty == null)
            return new ValidationResult("ContractId property not found.");
        var contractIdValue = (Guid?)contractIdProperty.GetValue(context.ObjectInstance);
        if (!x && contractIdValue != null)
            return new ValidationResult($"O campo {context.DisplayName} deve ser marcado quando o contrato estiver presente.");
        return ValidationResult.Success;
    }

    public static ValidationResult? ValidateContractId(Guid? x, ValidationContext context)
    {
        var rentedProperty = context.ObjectType.GetProperty("Rented");
        if (rentedProperty == null)
            return new ValidationResult("Rented property not found.");
        var rentedValue = (bool)(rentedProperty.GetValue(context.ObjectInstance) ?? throw new NullReferenceException());
        if (rentedValue && x == null)
            return new ValidationResult($"O campo {context.DisplayName} é obrigatório quando o equipamento for alugado.");
        return ValidationResult.Success;
    }

    public static ValidationResult? ValidateType(string x, ValidationContext context)
    {
        if (!Enum.TryParse(typeof(Domain.Enums.EquipmentType), x, out var _))
        {
            var types = string.Join(", ", Enum.GetNames(typeof(Domain.Enums.EquipmentType)));
            return new ValidationResult($"O campo {context.DisplayName} deve possuir um des sequintes valores: {types}.");
        }
        return ValidationResult.Success;
    }
}