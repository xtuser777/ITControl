using ITControl.Communication.Shared.Requests;

namespace ITControl.Communication.Appointments.Requests;

public class FindManyAppointmentsRequest : PageableRequest
{
    public string? Description { get; set; }
    public DateOnly? ScheduledAt { get; set; }
    public TimeOnly? ScheduledIn { get; set; }
    public string? Observation { get; set; }
    public Guid? UserId { get; set; }
    public Guid? CallId { get; set; }
    public Guid? LocationId { get; set; }
    public string? OrderByDescription { get; set; }
    public string? OrderByScheduledAt { get; set; }
    public string? OrderByScheduledIn { get; set; }
    public string? OrderByObservation { get; set; }
    public string? OrderByUser { get; set; }
    public string? OrderByCall { get; set; }
    public string? OrderByLocation { get; set; }
}