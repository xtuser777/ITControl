using ITControl.Communication.Shared.Requests;
using ITControl.Domain.Appointments.Params;

namespace ITControl.Communication.Appointments.Requests;

public class FindManyAppointmentsRequest : PageableRequest
{
    public string? Description { get; set; }
    public DateOnly? ScheduledAt { get; set; }
    public TimeOnly? ScheduledIn { get; set; }
    public string? Observation { get; set; }
    public Guid? UserId { get; set; }
    public Guid? CallId { get; set; }
    public string? OrderByDescription { get; set; }
    public string? OrderByScheduledAt { get; set; }
    public string? OrderByScheduledIn { get; set; }
    public string? OrderByObservation { get; set; }
    public string? OrderByUser { get; set; }
    public string? OrderByCall { get; set; }

    public static implicit operator FindManyAppointmentsRepositoryParams(FindManyAppointmentsRequest request) =>
        new()
        {
            Description = request.Description,
            ScheduledAt = request.ScheduledAt,
            ScheduledIn = request.ScheduledIn,
            Observation = request.Observation,
            UserId = request.UserId,
            CallId = request.CallId,
            OrderByDescription = request.OrderByDescription,
            OrderByScheduledAt = request.OrderByScheduledAt,
            OrderByScheduledIn = request.OrderByScheduledIn,
            OrderByObservation = request.OrderByObservation,
            OrderByUser = request.OrderByUser,
            OrderByCall = request.OrderByCall,
            Page = request.Page is null ? null : int.Parse(request.Page),
            Size = request.Size is null ? null : int.Parse(request.Size)
        };

    public static implicit operator CountAppointmentsRepositoryParams(FindManyAppointmentsRequest request) =>
        new()
        {
            Description = request.Description,
            ScheduledAt = request.ScheduledAt,
            ScheduledIn = request.ScheduledIn,
            Observation = request.Observation,
            UserId = request.UserId,
            CallId = request.CallId
        };
}