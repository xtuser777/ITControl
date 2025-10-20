using ITControl.Domain.Appointments.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Communication.Appointments.Requests;

public record OrderByAppointmentsRequest
{
    [FromHeader(Name = "X-Order-By-Description")]
    public string? Description { get; set; }
    [FromHeader(Name = "X-Order-By-Scheduled-At")]
    public string? ScheduledAt { get; set; }
    [FromHeader(Name = "X-Order-By-Scheduled-In")]
    public string? ScheduledIn { get; set; }
    [FromHeader(Name = "X-Order-By-Observation")]
    public string? Observation { get; set; }
    [FromHeader(Name = "X-Order-By-User")]
    public string? User { get; set; }
    [FromHeader(Name = "X-Order-By-Call")]
    public string? Call { get; set; }

    public static implicit operator OrderByAppointmentsRepositoryParams(OrderByAppointmentsRequest request) =>
        new()
        {
            Description = request.Description,
            ScheduledAt = request.ScheduledAt,
            ScheduledIn = request.ScheduledIn,
            Observation = request.Observation,
            User = request.User,
            Call = request.Call,
        };
}