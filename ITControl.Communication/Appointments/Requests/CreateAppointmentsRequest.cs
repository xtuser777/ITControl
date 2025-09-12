using ITControl.Communication.Shared.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Appointments.Requests;

public class CreateAppointmentsRequest
{
    [RequiredField]
    [StringMaxLength(100)]
    [Display(Name = "descrição")]
    public string Description { get; set; } = string.Empty;

    [RequiredField]
    [DateOnlyConverter]
    [DateValue]
    [DateGreaterThanCurrent]
    [Display(Name = "data agendada")]
    public DateOnly ScheduledAt { get; set; }

    [RequiredField]
    [TimeOnlyConverter]
    [TimeValue]
    [TimeGreaterThanCurrent("ScheduledAt")]
    [Display(Name = "hora agendada")]
    public TimeOnly ScheduledIn { get; set; }

    [StringMaxLength(255)]
    [Display(Name = "observação")]
    public string Observation { get; set; } = string.Empty;

    [RequiredField]
    [GuidValue]
    [Display(Name = "usuário")]
    public Guid UserId { get; set; }

    [RequiredField]
    [GuidValue]
    [Display(Name = "chamado")]
    public Guid CallId { get; set; }

    [RequiredField]
    [GuidValue]
    [Display(Name = "local")]
    public Guid LocationId { get; set; }
}