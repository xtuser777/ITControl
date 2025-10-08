using ITControl.Domain.Calls.Entities;
using ITControl.Domain.Users.Entities;

namespace ITControl.Domain.Appointments.Params;

public class UpdateAppointmentParams
{
    public string? Description { get; set; } = null;
    public DateOnly? ScheduledAt { get; set; } = null;
    public TimeOnly? ScheduledIn { get; set; } = null;
    public string? Observation { get; set; } = null;
    public Guid? UserId { get; set; } = null;
    public Guid? CallId { get; set; } = null;
    public User? User { get; set; } = null;
    public Call? Call { get; set; } = null;
}
