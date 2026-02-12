using ITControl.Domain.Treatments.Enums;
using ITControl.Domain.Treatments.Props;
using ITControl.Presentation.Calls.Requests;
using ITControl.Presentation.Shared.Attributes;
using ITControl.Presentation.Shared.Resources;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Presentation.Treatments.Requests;

public class CreateTreatmentsRequest
{
    [RequiredField]
    [StringMaxLength(100)]
    [Display(Name = nameof(Description), ResourceType = typeof(DisplayNames))]
    public string Description { get; set; } = string.Empty;

    [RequiredField]
    [DateValue]
    [DatePresentPast]
    [Display(Name = nameof(StartedAt), ResourceType = typeof(DisplayNames))]
    public DateOnly StartedAt { get; set; }

    [DateValue]
    [DateGreatherThan(nameof(StartedAt))]
    [Display(Name = nameof(EndedAt), ResourceType = typeof(DisplayNames))]
    public DateOnly? EndedAt { get; set; }

    [RequiredField]
    [TimeValue]
    [TimePresentPast]
    [Display(Name = nameof(StartedIn), ResourceType = typeof(DisplayNames))]
    public TimeOnly StartedIn { get; set; }

    [TimeValue]
    [Display(Name = nameof(EndedIn), ResourceType = typeof(DisplayNames))]
    public TimeOnly? EndedIn { get; set; }

    [EnumValue(typeof(TreatmentStatus))]
    [Display(Name = nameof(Status), ResourceType = typeof(DisplayNames))]
    public string Status { get; set; } = TreatmentStatus.Started.ToString();

    [RequiredField]
    [EnumValue(typeof(TreatmentType))]
    [Display(Name = nameof(Type), ResourceType = typeof(DisplayNames))]
    public string Type { get; set; } = string.Empty;

    [StringMaxLength(255)]
    [Display(Name = nameof(Observation), ResourceType = typeof(DisplayNames))]
    public string Observation { get; set; } = string.Empty;

    [StringMaxLength(50)]
    [Display(Name = nameof(ExternalProtocol), ResourceType = typeof(DisplayNames))]
    public string ExternalProtocol { get; set; } = string.Empty;

    [GuidValue]
    [CallConnection]
    [Display(Name = nameof(CallId), ResourceType = typeof(DisplayNames))]
    public Guid? CallId { get; set; }

    [RequiredField]
    [GuidValue]
    [UserConnection]
    [Display(Name = nameof(UserId), ResourceType = typeof(DisplayNames))]
    public Guid UserId { get; set; }

    public CreateCallsRequest? Call { get; set; }

    public static implicit operator TreatmentProps(
        CreateTreatmentsRequest request) =>
        new()
        {
            Description = request.Description,
            Protocol = Guid.NewGuid().ToString().ToUpper().Replace("-", ""),
            StartedAt = request.StartedAt,
            EndedAt = request.EndedAt,
            StartedIn = request.StartedIn,
            EndedIn = request.EndedIn,
            Status = Enum.Parse<TreatmentStatus>(request.Status),
            Type = Enum.Parse<TreatmentType>(request.Type),
            Observation = request.Observation,
            ExternalProtocol = request.ExternalProtocol,
            CallId = request.CallId,
            UserId = request.UserId
        };
}
