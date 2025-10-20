using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Appointments.Params;

public record FindManyAppointmentsRepositoryParams : FindManyRepositoryParams
{
    public string? Description { get; set; } = null;
    public DateOnly? ScheduledAt { get; set; } = null;
    public TimeOnly? ScheduledIn { get; set; } = null;
    public string? Observation { get; set; } = null;
    public Guid? UserId { get; set; } = null;
    public Guid? CallId { get; set; } = null;
}
