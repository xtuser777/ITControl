using ITControl.Communication.Shared.Requests;
using ITControl.Communication.Shared.Utils;
using ITControl.Domain.Appointments.Params;
using ITControl.Domain.Shared.Params;

namespace ITControl.Communication.Appointments.Requests;

public record FindManyAppointmentsRequest : PageableRequest
{
    public string? Description { get; set; }
    public DateOnly? ScheduledAt { get; set; }
    public TimeOnly? ScheduledIn { get; set; }
    public string? Observation { get; set; }
    public Guid? UserId { get; set; }
    public Guid? CallId { get; set; }

    public static implicit operator FindManyAppointmentsRepositoryParams(FindManyAppointmentsRequest request) =>
        new()
        {
            Description = request.Description,
            ScheduledAt = request.ScheduledAt,
            ScheduledIn = request.ScheduledIn,
            Observation = request.Observation,
            UserId = request.UserId,
            CallId = request.CallId,
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

    public static implicit operator PaginationParams(FindManyAppointmentsRequest request) =>
        new()
        {
            Page = Parser.ToIntOptional(request.Page),
            Size = Parser.ToIntOptional(request.Size)
        };
}