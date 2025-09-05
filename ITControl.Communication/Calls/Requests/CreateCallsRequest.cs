using ITControl.Communication.Shared.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Calls.Requests;

public class CreateCallsRequest
{
    [RequiredField]
    [StringMaxLength(64)]
    [Display(Name = "título")]
    public string Title { get; set; } = string.Empty;

    [RequiredField]
    [StringMaxLength(255)]
    [Display(Name = "descrição")]
    public string Description { get; set; } = string.Empty;

    [RequiredField]
    [CustomValidation(typeof(CreateCallsRequest), nameof(ValidateReason))]
    [Display(Name = "motivo")]
    public string Reason { get; set; } = string.Empty;

    [RequiredField]
    [GuidConverter]
    [GuidValue]
    [Display(Name = "usuário")]
    public Guid UserId { get; set; }

    [GuidNullableConverter]
    [GuidValue]
    [Display(Name = "equipamento")]
    public Guid? EquipmentId { get; set; }

    [GuidNullableConverter]
    [GuidValue]
    [Display(Name = "sistema")]
    public Guid? SystemId { get; set; }

    public static ValidationResult? ValidateReason(string reason, ValidationContext context)
    {
        var validReasons = Enum.GetNames(typeof(Domain.Enums.CallReason));
        if (!validReasons.Contains(reason))
        {
            var reasons = string.Join(", ", validReasons);
            return new ValidationResult($"O campo {context.DisplayName} deve ser um dos seguintes valores: {reasons}.");
        }
        return ValidationResult.Success;
    }
}
