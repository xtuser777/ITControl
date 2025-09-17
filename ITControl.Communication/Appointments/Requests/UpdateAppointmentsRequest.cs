using System.ComponentModel.DataAnnotations;
using ITControl.Communication.Shared.Resources;
using ITControl.Communication.Shared.Attributes;

namespace ITControl.Communication.Appointments.Requests;

public class UpdateAppointmentsRequest
{
    [StringMaxLength(100)]
    [Display(Name = nameof(Description), ResourceType = typeof(DisplayNames))]

    public string? Description { get; set; }
    
    [DateValue]
    [DateGreaterThanCurrent]
    [Display(Name = nameof(ScheduledAt), ResourceType = typeof(DisplayNames))]
    public DateOnly? ScheduledAt { get; set; }

    [TimeValue]
    [TimeGreaterThanCurrent(nameof(ScheduledAt))]
    public TimeOnly? ScheduledIn { get; set; }
    
    [StringMaxLength(255)]
    [Display(Name = nameof(Observation), ResourceType = typeof(DisplayNames))]
    public string? Observation { get; set; }

    [GuidValue]
    [UserConnection]
    [Display(Name = nameof(UserId), ResourceType = typeof(DisplayNames))]
    public Guid? UserId { get; set; }

    [GuidValue]
    [CallConnection]
    [Display(Name = nameof(UserId), ResourceType = typeof(DisplayNames))]
    public Guid? CallId { get; set; }

    [GuidValue]
    [LocationConnection]
    [Display(Name = nameof(LocationId), ResourceType = typeof(DisplayNames))]
    public Guid? LocationId { get; set; }
}