using ITControl.Domain.Shared.Params2;

namespace ITControl.Domain.Appointments.Params;

public record FindManyAppointmentsParams : FindManyParams
{
    public string? Description { get; set; }
    public DateOnly? ScheduledAt { get; set; }
    public TimeOnly? ScheduledIn { get; set; }
    public string? Observation { get; set; }
    public Guid? UserId { get; set; }
    public Guid? CallId { get; set; }
}
