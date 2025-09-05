using ITControl.Communication.Shared.Attributes;
using ITControl.Domain.Shared.Messages;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Treatments.Requests;

public class UpdateTreatmentsRequest
{
    [StringMaxLength(100)]
    [Display(Name = "descrição")]
    public string? Description { get; set; }

    [DateOnlyNullableConverter]
    [DateValue]
    [DatePresentPast]
    [Display(Name = "data de início")]
    public DateOnly? StartedAt { get; set; }

    [DateOnlyNullableConverter]
    [DateValue]
    [DateGreatherThan("StartedAt")]
    [Display(Name = "data de término")]
    public DateOnly? EndedAt { get; set; }

    [TimeOnlyNullableConverter]
    [TimeValue]
    [TimePresentPast]
    [Display(Name = "hora de início")]
    public TimeOnly? StartedIn { get; set; }

    [TimeOnlyNullableConverter]
    [TimeValue]
    [Display(Name = "hora de término")]
    public TimeOnly? EndedIn { get; set; }

    [CustomValidation(typeof(UpdateTreatmentsRequest), nameof(ValidateStatus))]
    [Display(Name = "status")]
    public string? Status { get; set; }

    [CustomValidation(typeof(UpdateTreatmentsRequest), nameof(ValidateType))]
    [Display(Name = "tipo")]
    public string? Type { get; set; }
    
    [StringMaxLength(255)]
    [Display(Name = "observação")]
    public string? Observation { get; set; }
    
    [StringMaxLength(50)]
    [Display(Name = "protocolo externo")]
    public string? ExternalProtocol { get; set; }

    [GuidNullableConverter]
    [GuidValue]
    [Display(Name = "chamado")]
    public Guid? CallId { get; set; }

    [GuidNullableConverter]
    [GuidValue]
    [Display(Name = "usuário")]
    public Guid? UserId { get; set; }

    public static ValidationResult? ValidateStatus(string? status, ValidationContext context)
    {
        if (status == null) return ValidationResult.Success;
        var allowedStatuses = Enum.GetNames(typeof(Domain.Enums.TreatmentStatus));
        if (!allowedStatuses.Contains(status))
        {
            var statuses = string.Join(", ", allowedStatuses);
            var errorMessage = $"O campo {context.DisplayName} deve ser um dos seguintes valores: {statuses}.";
            return new ValidationResult(errorMessage);
        }
        return ValidationResult.Success;
    }

    public static ValidationResult? ValidateType(string? type, ValidationContext context)
    {
        if (type == null) return ValidationResult.Success;
        var allowedTypes = Enum.GetNames(typeof(Domain.Enums.TreatmentType));
        if (!allowedTypes.Contains(type))
        {
            var types = string.Join(", ", allowedTypes);
            var errorMessage = $"O campo {context.DisplayName} deve ser um dos seguintes valores: {types}.";
            return new ValidationResult(errorMessage);
        }
        return ValidationResult.Success;
    }
}
