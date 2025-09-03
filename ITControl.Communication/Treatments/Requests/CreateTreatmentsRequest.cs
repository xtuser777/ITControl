using ITControl.Communication.Shared.Attributes;
using ITControl.Domain.Shared.Messages;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Treatments.Requests;

public class CreateTreatmentsRequest
{
    [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "REQUIRED")]
    [MaxLength(100, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MAX_LENGTH")]
    [Display(Name = "descrição")]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "REQUIRED")]
    [DataType(DataType.Date, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "INVALID_DATE")]
    [DatePresentPast]
    [Display(Name = "data de início")]
    public DateOnly StartedAt { get; set; }

    [DataType(DataType.Date, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "INVALID_DATE")]
    [DateGreatherThan("StartedAt")]
    [Display(Name = "data de término")]
    public DateOnly? EndedAt { get; set; }

    [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "REQUIRED")]
    [DataType(DataType.Time, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "INVALID_TIME")]
    [TimePresentPast]
    [Display(Name = "hora de início")]
    public TimeOnly StartedIn { get; set; }

    [DataType(DataType.Time, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "INVALID_TIME")]
    [Display(Name = "hora de término")]
    public TimeOnly? EndedIn { get; set; }

    [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "REQUIRED")]
    [CustomValidation(typeof(CreateTreatmentsRequest), nameof(ValidateStatus))]
    [Display(Name = "status")]
    public string Status { get; set; } = string.Empty;

    [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "REQUIRED")]
    [CustomValidation(typeof(CreateTreatmentsRequest), nameof(ValidateType))]
    [Display(Name = "tipo")]
    public string Type { get; set; } = string.Empty;

    [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "REQUIRED")]
    [MaxLength(255, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MAX_LENGTH")]
    [Display(Name = "observação")]
    public string Observation { get; set; } = string.Empty;

    [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "REQUIRED")]
    [MaxLength(50, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MAX_LENGTH")]
    [Display(Name = "protocolo externo")]
    public string ExternalProtocol { get; set; } = string.Empty;

    [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "REQUIRED")]
    [GuidValue]
    [Display(Name = "chamado")]
    public Guid CallId { get; set; }

    [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "REQUIRED")]
    [GuidValue]
    [Display(Name = "usuário")]
    public Guid UserId { get; set; }

    public static ValidationResult? ValidateStatus(string status, ValidationContext context)
    {
        var allowedStatuses = Enum.GetNames(typeof(Domain.Enums.TreatmentStatus));
        if (!allowedStatuses.Contains(status))
        { 
            var statuses = string.Join(", ", allowedStatuses);
            var errorMessage = $"O campo {context.DisplayName} deve ser um dos seguintes valores: {statuses}.";
            return new ValidationResult(errorMessage);
        }
        return ValidationResult.Success;
    }

    public static ValidationResult? ValidateType(string type, ValidationContext context)
    {
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
