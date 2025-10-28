namespace ITControl.Presentation.Appointments.Responses;

public class FindOneAppointmentsResponse
{
    public Guid Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateOnly ScheduledAt { get; set; }
    public TimeOnly ScheduledIn { get; set; }
    public string Observation { get; set; } = string.Empty;
    public Guid UserId { get; set; }
    public Guid CallId { get; set; }
    public Guid LocationId { get; set; }
    public FindOneAppointmentsUserResponse? User { get; set; }
    public FindOneAppointmentsCallResponse? Call { get; set; }
}