using System.ComponentModel.DataAnnotations;
using ITControl.Presentation.Shared.Attributes;
using ITControl.Presentation.Shared.Resources;
using ITControl.Presentation.Shared.Utils;
using ITControl.Domain.Treatments.Enums;
using ITControl.Domain.Treatments.Params;

namespace ITControl.Presentation.Treatments.Requests;

public class UpdateTreatmentsRequest
{
    [StringMinLength(1)]
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

    [EnumValue(typeof(TreatmentStatus))]
    [Display(Name = nameof(Status), ResourceType = typeof(DisplayNames))]
    public string? Status { get; set; }

    [EnumValue(typeof(TreatmentType))]
    [Display(Name = nameof(Type), ResourceType = typeof(DisplayNames))]
    public string? Type { get; set; }
    
    [StringMinLength(1)]
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

    public static implicit operator UpdateTreatmentParams(
        UpdateTreatmentsRequest request) =>
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
}
