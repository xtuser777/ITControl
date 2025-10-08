using ITControl.Communication.Shared.Attributes;
using ITControl.Communication.Shared.Resources;
using ITControl.Communication.Shared.Utils;
using ITControl.Domain.Shared.Messages;
using ITControl.Domain.Treatments.Enums;
using ITControl.Domain.Treatments.Params;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Treatments.Requests;

public class UpdateTreatmentsRequest
{
    [StringMaxLength(100)]
    [Display(Name = nameof(Description), ResourceType = typeof(DisplayNames))]
    public string? Description { get; set; }

    [DateValue]
    [DatePresentPast]
    [Display(Name = nameof(StartedAt), ResourceType = typeof(DisplayNames))]
    public DateOnly? StartedAt { get; set; }

    [DateValue]
    [DateGreatherThan(nameof(StartedAt))]
    [Display(Name = nameof(EndedAt), ResourceType = typeof(DisplayNames))]
    public DateOnly? EndedAt { get; set; }

    [TimeValue]
    [TimePresentPast]
    [Display(Name = nameof(StartedIn), ResourceType = typeof(DisplayNames))]
    public TimeOnly? StartedIn { get; set; }

    [TimeValue]
    [Display(Name = nameof(EndedIn), ResourceType = typeof(DisplayNames))]
    public TimeOnly? EndedIn { get; set; }

    [CustomValidation(typeof(UpdateTreatmentsRequest), nameof(ValidateStatus))]
    [Display(Name = nameof(Status), ResourceType = typeof(DisplayNames))]
    public string? Status { get; set; }

    [CustomValidation(typeof(UpdateTreatmentsRequest), nameof(ValidateType))]
    [Display(Name = nameof(Type), ResourceType = typeof(DisplayNames))]
    public string? Type { get; set; }
    
    [StringMaxLength(255)]
    [Display(Name = nameof(Observation), ResourceType = typeof(DisplayNames))]
    public string? Observation { get; set; }
    
    [StringMaxLength(50)]
    [Display(Name = nameof(ExternalProtocol), ResourceType = typeof(DisplayNames))]
    public string? ExternalProtocol { get; set; }

    [GuidValue]
    [CallConnection]
    [Display(Name = nameof(CallId), ResourceType = typeof(DisplayNames))]
    public Guid? CallId { get; set; }

    [GuidValue]
    [UserConnection]
    [Display(Name = nameof(UserId), ResourceType = typeof(DisplayNames))]
    public Guid? UserId { get; set; }

    public static implicit operator UpdateTreatmentParams(UpdateTreatmentsRequest request) =>
        new()
        {
            Description = request.Description,
            StartedAt = request.StartedAt,
            EndedAt = request.EndedAt,
            StartedIn = request.StartedIn,
            EndedIn = request.EndedIn,
            Status = Parser.ToEnumOptional<TreatmentStatus>(request.Status),
            Type = Parser.ToEnumOptional<TreatmentType>(request.Type),
            Observation = request.Observation,
            ExternalProtocol = request.ExternalProtocol,
            CallId = request.CallId,
            UserId = request.UserId
        };

    public static ValidationResult? ValidateStatus(string? status, ValidationContext context)
    {
        if (status == null) return ValidationResult.Success;
        var allowedStatuses = Enum.GetNames(typeof(TreatmentStatus));
        if (!allowedStatuses.Contains(status))
        {
            var statuses = string.Join(", ", allowedStatuses);
            var errorMessage = string.Format(Errors.MustBeAOneOfTheseValues, context.DisplayName, statuses);
            return new ValidationResult(errorMessage);
        }
        return ValidationResult.Success;
    }

    public static ValidationResult? ValidateType(string? type, ValidationContext context)
    {
        if (type == null) return ValidationResult.Success;
        var allowedTypes = Enum.GetNames(typeof(TreatmentType));
        if (!allowedTypes.Contains(type))
        {
            var types = string.Join(", ", allowedTypes);
            var errorMessage = string.Format(Errors.MustBeAOneOfTheseValues, context.DisplayName, types);
            return new ValidationResult(errorMessage);
        }
        return ValidationResult.Success;
    }
}
