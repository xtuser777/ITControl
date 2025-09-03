using ITControl.Domain.Shared.Messages;
using System.ComponentModel.DataAnnotations;
using ITControl.Communication.Shared.Attributes;

namespace ITControl.Communication.Appointments.Requests;

public class UpdateAppointmentsRequest
{
    [MaxLength(
        100, 
        ErrorMessageResourceType = typeof(Errors), 
        ErrorMessageResourceName = "MAX_LENGTH")]
    [Display(Name = "descrição")]
    public string? Description { get; set; }
    
    [DataType(
        DataType.Date, 
        ErrorMessageResourceType = typeof(Errors), 
        ErrorMessageResourceName = "INVALID_DATE")]
    [DateGreaterThanCurrent(
        ErrorMessageResourceType = typeof(Errors), 
        ErrorMessageResourceName = "DATE_GREATER_THAN_CURRENT")]
    [Display(Name = "data de agendameto")]
    public DateOnly? ScheduledAt { get; set; }
    
    [DataType(
        DataType.Time, 
        ErrorMessageResourceType = typeof(Errors), 
        ErrorMessageResourceName = "INVALID_TIME")]
    [TimeGreaterThanCurrent(
        "ScheduledAt",
        ErrorMessageResourceType = typeof(Errors),
        ErrorMessageResourceName = "TIME_GREATER_THAN_CURRENT")]
    public TimeOnly? ScheduledIn { get; set; }
    
    [MaxLength(
        255, 
        ErrorMessageResourceType = typeof(Errors), 
        ErrorMessageResourceName = "MAX_LENGTH")]
    [Display(Name = "observação")]
    public string? Observation { get; set; }
    public Guid? UserId { get; set; }
    public Guid? CallId { get; set; }
    public Guid? LocationId { get; set; }
}