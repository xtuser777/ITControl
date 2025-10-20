using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Appointments.Params;

public record OrderByAppointmentsRepositoryParams : OrderByRepositoryParams
{
    public string? Description { get; set; } = null;
    public string? ScheduledAt { get; set; } = null;
    public string? ScheduledIn { get; set; } = null;
    public string? Observation { get; set; } = null;
    public string? User { get; set; } = null;
    public string? Call { get; set; } = null;
}
