using System.ComponentModel.DataAnnotations;
using ITControl.Communication.Shared.Attributes;

namespace ITControl.Communication.Appointments.Requests;

public class UpdateAppointmentsRequest
{
    [StringMaxLength(100)]
    [Display(Name = "descrição")]
    public string? Description { get; set; }
    
    [DateOnlyNullableConverter]
    [DateValue]
    [DateGreaterThanCurrent]
    [Display(Name = "data de agendameto")]
    public DateOnly? ScheduledAt { get; set; }

    [TimeOnlyNullableConverter]
    [TimeValue]
    [TimeGreaterThanCurrent("ScheduledAt")]
    public TimeOnly? ScheduledIn { get; set; }
    
    [StringMaxLength(255)]
    [Display(Name = "observação")]
    public string? Observation { get; set; }

    [GuidNullableConverter]
    [GuidValue]
    [Display(Name = "usuário")]
    public Guid? UserId { get; set; }

    [GuidNullableConverter]
    [GuidValue]
    [Display(Name = "chamado")]
    public Guid? CallId { get; set; }

    [GuidNullableConverter]
    [GuidValue]
    [Display(Name = "local")]
    public Guid? LocationId { get; set; }
}