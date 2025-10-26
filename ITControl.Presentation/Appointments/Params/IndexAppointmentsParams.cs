using ITControl.Application.Shared.Params;
using ITControl.Domain.Appointments.Params;
using ITControl.Domain.Shared.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Appointments.Params;

public record IndexAppointmentsParams : PaginationParams
{
    public string? Description { get; init; }
    public DateOnly? ScheduledAt { get; init; }
    public TimeOnly? ScheduledIn { get; init; }
    public string? Observation { get; init; }
    public Guid? UserId { get; init; }
    public Guid? CallId { get; init; }
    
    [FromHeader(Name = "X-Order-By-Description")]
    public string? OrderByDescription { get; init; }
    [FromHeader(Name = "X-Order-By-Scheduled-At")]
    public string? OrderByScheduledAt { get; init; }
    [FromHeader(Name = "X-Order-By-Scheduled-In")]
    public string? OrderByScheduledIn { get; init; }
    [FromHeader(Name = "X-Order-By-Observation")]
    public string? OrderByObservation { get; init; }
    [FromHeader(Name = "X-Order-By-User")]
    public string? OrderByUser { get; init; }
    [FromHeader(Name = "X-Order-By-Call")]
    public string? OrderByCall { get; init; }

    public static implicit operator OrderByAppointmentsParams(
        IndexAppointmentsParams request) =>
        new()
        {
            Description = request.OrderByDescription,
            ScheduledAt = request.OrderByScheduledAt,
            ScheduledIn = request.OrderByScheduledIn,
            Observation = request.OrderByObservation,
            User = request.OrderByUser,
            Call = request.OrderByCall,
        };

    public static implicit operator FindManyAppointmentsParams(
        IndexAppointmentsParams request) =>
        new()
        {
            Description = request.Description,
            ScheduledAt = request.ScheduledAt,
            ScheduledIn = request.ScheduledIn,
            Observation = request.Observation,
            UserId = request.UserId,
            CallId = request.CallId,
        };

    public static implicit operator CountAppointmentsParams(
        IndexAppointmentsParams request) =>
        new()
        {
            Description = request.Description,
            ScheduledAt = request.ScheduledAt,
            ScheduledIn = request.ScheduledIn,
            Observation = request.Observation,
            UserId = request.UserId,
            CallId = request.CallId
        };

    public static implicit operator FindManyServiceParams(
        IndexAppointmentsParams indexParams) =>
        new()
        {
            FindManyParams = indexParams,
            OrderByParams = indexParams,
            PaginationParams = indexParams
        };

    public static implicit operator FindManyPaginationServiceParams(
        IndexAppointmentsParams indexParams) =>
        new()
        {
            CountParams = indexParams,
            PaginationParams = indexParams
        };
}
