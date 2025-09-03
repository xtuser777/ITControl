using ITControl.Communication.Shared.Attributes;
using ITControl.Domain.Shared.Messages;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Appointments.Requests;

public class CreateAppointmentsRequest
{
    [Required(
        ErrorMessageResourceType = typeof(Errors), 
        ErrorMessageResourceName = "REQUIRED")]
    [MaxLength(
        100, 
        ErrorMessageResourceType = typeof(Errors), 
        ErrorMessageResourceName = "MAX_LENGTH")]
    [Display(Name = "descrição")]
    public string Description { get; set; } = string.Empty;

    [Required(
        ErrorMessageResourceType = typeof(Errors), 
        ErrorMessageResourceName = "REQUIRED")]
    [DataType(
        DataType.Date, 
        ErrorMessageResourceType = typeof(Errors), 
        ErrorMessageResourceName = "INVALID_DATE")]
    [DateGreaterThanCurrent(
        ErrorMessageResourceType = typeof(Errors), 
        ErrorMessageResourceName = "DATE_GREATER_THAN_CURRENT")]
    [Display(Name = "data agendada")]
    public DateOnly ScheduledAt { get; set; }

    [Required(
        ErrorMessageResourceType = typeof(Errors), 
        ErrorMessageResourceName = "REQUIRED")]
    [DataType(
        DataType.Time, 
        ErrorMessageResourceType = typeof(Errors), 
        ErrorMessageResourceName = "INVALID_TIME")]
    [TimeGreaterThanCurrent(
        "ScheduledAt",
        ErrorMessageResourceType = typeof(Errors),
        ErrorMessageResourceName = "TIME_GREATER_THAN_CURRENT")]
    [Display(Name = "hora agendada")]
    public TimeOnly ScheduledIn { get; set; }

    [MaxLength(
        255, 
        ErrorMessageResourceType = typeof(Errors), 
        ErrorMessageResourceName = "MAX_LENGTH")]
    [Display(Name = "observação")]
    public string Observation { get; set; } = string.Empty;

    [Required(
        ErrorMessageResourceType = typeof(Errors), 
        ErrorMessageResourceName = "REQUIRED")]
    [GuidValue]
    [Display(Name = "usuário")]
    public Guid UserId { get; set; }

    [Required(
        ErrorMessageResourceType = typeof(Errors), 
        ErrorMessageResourceName = "REQUIRED")]
    [GuidValue]
    [Display(Name = "chamado")]
    public Guid CallId { get; set; }

    [Required(
        ErrorMessageResourceType = typeof(Errors), 
        ErrorMessageResourceName = "REQUIRED")]
    [GuidValue]
    [Display(Name = "local")]
    public Guid LocationId { get; set; }
}