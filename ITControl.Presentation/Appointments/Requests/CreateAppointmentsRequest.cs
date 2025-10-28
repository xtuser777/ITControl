using System.ComponentModel.DataAnnotations;
using ITControl.Presentation.Shared.Attributes;
using ITControl.Presentation.Shared.Resources;
using ITControl.Domain.Appointments.Params;

namespace ITControl.Presentation.Appointments.Requests;

public record CreateAppointmentsRequest
{
    [RequiredField]
    [StringMaxLength(100)]
    [Display(Name = nameof(Description), ResourceType = typeof(DisplayNames))]
    public string Description { get; set; } = string.Empty;

    [RequiredField]
    [DateValue]
    [DateGreaterThanCurrent]
    [Display(Name = nameof(ScheduledAt), ResourceType = typeof(DisplayNames))]
    public DateOnly ScheduledAt { get; set; }

    [RequiredField]
    [TimeValue]
    [TimeGreaterThanCurrent(nameof(ScheduledAt))]
    [Display(Name = nameof(ScheduledIn), ResourceType = typeof(DisplayNames))]
    public TimeOnly ScheduledIn { get; set; }

    [StringMaxLength(255)]
    [Display(Name = nameof(Observation), ResourceType = typeof(DisplayNames))]
    public string Observation { get; set; } = string.Empty;

    [RequiredField]
    [GuidValue]
    [UserConnection]
    [Display(Name = nameof(UserId), ResourceType = typeof(DisplayNames))]
    public Guid UserId { get; set; }

    [RequiredField]
    [GuidValue]
    [CallConnection]
    [Display(Name = nameof(CallId), ResourceType = typeof(DisplayNames))]
    public Guid CallId { get; set; }

    public static implicit operator AppointmentParams(
        CreateAppointmentsRequest request) =>
        new()
        {
            Description = request.Description,
            ScheduledAt = request.ScheduledAt,
            ScheduledIn = request.ScheduledIn,
            Observation = request.Observation,
            UserId = request.UserId,
            CallId = request.CallId
        };
}