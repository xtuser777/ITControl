using ITControl.Domain.Shared.Messages;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Appointments.Requests;

public class UpdateAppointmentsRequest
{
    [MaxLength(100, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MAX_LENGTH")]
    public string? Description { get; set; }
    public DateOnly? ScheduledAt { get; set; }
    public TimeOnly? ScheduledIn { get; set; }
    
    [MaxLength(255, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MAX_LENGTH")]
    public string? Observation { get; set; }
    public Guid? UserId { get; set; }
    public Guid? CallId { get; set; }
    public Guid? LocationId { get; set; }
}