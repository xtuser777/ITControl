using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Appointments.Params;

public record AppointmentParams : EntityParams
{
    public string Description { get; init; } = null!;
    public DateOnly ScheduledAt { get; init; }
    public TimeOnly ScheduledIn { get; init; }
    public string Observation { get; init; } = null!;
    public Guid UserId { get; init; }
    public Guid CallId { get; init; }
}
