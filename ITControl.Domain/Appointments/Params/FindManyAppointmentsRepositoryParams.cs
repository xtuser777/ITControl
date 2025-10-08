namespace ITControl.Domain.Appointments.Params;

public class FindManyAppointmentsRepositoryParams
{
    public string? Description { get; set; } = null;
    public DateOnly? ScheduledAt { get; set; } = null;
    public TimeOnly? ScheduledIn { get; set; } = null;
    public string? Observation { get; set; } = null;
    public Guid? UserId { get; set; } = null;
    public Guid? CallId { get; set; } = null;
    public string? OrderByDescription { get; set; } = null;
    public string? OrderByScheduledAt { get; set; } = null;
    public string? OrderByScheduledIn { get; set; } = null;
    public string? OrderByObservation { get; set; } = null;
    public string? OrderByUser { get; set; } = null;
    public string? OrderByCall { get; set; } = null;
    public int? Page { get; set; } = null;
    public int? Size { get; set; } = null;

    public static implicit operator CountAppointmentsRepositoryParams(FindManyAppointmentsRepositoryParams @params) =>
        new()
        {
            Description = @params.Description,
            ScheduledAt = @params.ScheduledAt,
            ScheduledIn = @params.ScheduledIn,
            Observation = @params.Observation,
            UserId = @params.UserId,
            CallId = @params.CallId
        };

    public void Deconstruct(
        out int? page,
        out int? size)
    {
        page = Page;
        size = Size;
    }
}
