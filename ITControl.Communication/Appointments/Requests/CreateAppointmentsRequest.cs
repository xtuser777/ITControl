namespace ITControl.Communication.Appointments.Requests;

public class CreateAppointmentsRequest
{
    public string Description { get; set; } = string.Empty;
    public DateOnly ScheduledAt { get; set; }
    public TimeOnly ScheduledIn { get; set; }
    public string Observation { get; set; } = string.Empty;
    public Guid UserId { get; set; }
    public Guid CallId { get; set; }
    public Guid LocationId { get; set; }
}