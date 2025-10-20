namespace ITControl.Domain.Appointments.Params;

public record AppointmentParams
{
    public string Description { get; set; } = null!;
    public DateOnly ScheduledAt { get; set; }
    public TimeOnly ScheduledIn { get; set; }
    public string Observation { get; set; } = null!;
    public Guid UserId { get; set; }
    public Guid CallId { get; set; }
}
