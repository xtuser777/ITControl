using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Appointments.Params;

public record UpdateAppointmentParams : UpdateEntityParams
{
    public string? Description { get; init; }
    public DateOnly? ScheduledAt { get; init; }
    public TimeOnly? ScheduledIn { get; init; }
    public string? Observation { get; init; }
    public Guid? UserId { get; init; }
    public Guid? CallId { get; init; }
}
