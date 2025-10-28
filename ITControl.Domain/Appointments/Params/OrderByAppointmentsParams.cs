using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Appointments.Params;

public record OrderByAppointmentsParams : OrderByParams
{
    public string? Description { get; set; }
    public string? ScheduledAt { get; set; }
    public string? ScheduledIn { get; set; }
    public string? Observation { get; set; }
    public string? User { get; set; }
    public string? Call { get; set; }
}
