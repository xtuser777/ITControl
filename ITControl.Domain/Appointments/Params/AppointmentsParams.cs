using ITControl.Domain.Calls.Entities;
using ITControl.Domain.Users.Entities;

namespace ITControl.Domain.Appointments.Params;

public class AppointmentsParams
{
    public string Description { get; set; } = null!;
    public DateOnly ScheduledAt { get; set; }
    public TimeOnly ScheduledIn { get; set; }
    public string Observation { get; set; } = null!;
    public Guid UserId { get; set; }
    public Guid CallId { get; set; }
    public User? User { get; set; }
    public Call? Call { get; set; }
}
