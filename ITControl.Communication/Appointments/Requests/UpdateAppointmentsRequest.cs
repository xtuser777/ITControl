namespace ITControl.Communication.Appointments.Requests;

public class UpdateAppointmentsRequest
{
    public string? Description { get; set; }
    public DateOnly? ScheduledAt { get; set; }
    public TimeOnly? ScheduledIn { get; set; }
    public string? Observation { get; set; }
    public Guid? UserId { get; set; }
    public Guid? CallId { get; set; }
    public Guid? LocationId { get; set; }
}