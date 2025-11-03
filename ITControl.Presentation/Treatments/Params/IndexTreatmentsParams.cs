using ITControl.Application.Shared.Params;
using ITControl.Domain.Shared.Params;
using ITControl.Domain.Shared.Utils;
using ITControl.Domain.Treatments.Enums;
using ITControl.Domain.Treatments.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Treatments.Params;

public record IndexTreatmentsParams : PaginationParams
{
    public string? Description { get; set; }
    public string? Protocol { get; set; }
    public DateOnly? StartedAt { get; set; }
    public DateOnly? EndedAt { get; set; }
    public TimeOnly? StartedIn { get; set; }
    public TimeOnly? EndedIn { get; set; }
    public string? Status { get; set; }
    public string? Type { get; set; }
    public string? Observation { get; set; }
    public string? ExternalProtocol { get; set; }
    public Guid? CallId { get; set; }
    public Guid? UserId { get; set; }
    
    [FromHeader(Name = "X-Order-By-Description")]
    public string? OrderByDescription { get; set; }
    [FromHeader(Name = "X-Order-By-Protocol")	]
    public string? OrderByProtocol { get; set; }
    [FromHeader(Name = "X-Order-By-Started-At")	]
    public string? OrderByStartedAt { get; set; }
    [FromHeader(Name = "X-Order-By-Ended-At")	]
    public string? OrderByEndedAt { get; set; }
    [FromHeader(Name = "X-Order-By-Started-In")	]
    public string? OrderByStartedIn { get; set; }
    [FromHeader(Name = "X-Order-By-Ended-In")	]
    public string? OrderByEndedIn { get; set; }
    [FromHeader(Name = "X-Order-By-Status")	]
    public string? OrderByStatus { get; set; }
    [FromHeader(Name = "X-Order-By-Type")	]
    public string? OrderByType{ get; set; }
    [FromHeader(Name = "X-Order-By-Observation")	]
    public string? OrderByObservation { get; set; }
    [FromHeader(Name = "X-Order-By-External-Protocol")	]
    public string? OrderByExternalProtocol { get; set; }
    [FromHeader(Name = "X-Order-By-Call")	]
    public string? OrderByCall{ get; set; }
    [FromHeader(Name = "X-Order-By-User")	]
    public string? OrderByUser{ get; set; }

    public static implicit operator OrderByTreatmentsParams(
        IndexTreatmentsParams request)
        => new()
        {
            Description = request.OrderByDescription,
            Protocol = request.OrderByProtocol,
            StartedAt = request.OrderByStartedAt,
            EndedAt = request.OrderByEndedAt,
            StartedIn = request.OrderByStartedIn,
            EndedIn = request.OrderByEndedIn,
            Status = request.OrderByStatus,
            Type = request.OrderByType,
            Observation = request.OrderByObservation,
            ExternalProtocol = request.OrderByExternalProtocol,
            Call = request.OrderByCall,
            User = request.OrderByUser,
        };

    public static implicit operator FindManyTreatmentsParams(
        IndexTreatmentsParams request) =>
        new()
        {
            Description = request.Description,
            Protocol = request.Protocol,
            StartedAt = request.StartedAt,
            EndedAt = request.EndedAt,
            StartedIn = request.StartedIn,
            EndedIn = request.EndedIn,
            Status = Parser.ToEnumOptional<TreatmentStatus>(request.Status),
            Type = Parser.ToEnumOptional<TreatmentType>(request.Type),
            Observation = request.Observation,
            ExternalProtocol = request.ExternalProtocol,
            CallId = request.CallId,
            UserId = request.UserId,
        };

    public static implicit operator CountTreatmentsParams(
        IndexTreatmentsParams request) =>
        new()
        {
            Description = request.Description,
            Protocol = request.Protocol,
            StartedAt = request.StartedAt,
            EndedAt = request.EndedAt,
            StartedIn = request.StartedIn,
            EndedIn = request.EndedIn,
            Status = Parser.ToEnumOptional<TreatmentStatus>(request.Status),
            Type = Parser.ToEnumOptional<TreatmentType>(request.Type),
            Observation = request.Observation,
            ExternalProtocol = request.ExternalProtocol,
            CallId = request.CallId,
            UserId = request.UserId
        };

    public static implicit operator FindManyServiceParams(
        IndexTreatmentsParams parameters)
        => new()
        {
            FindManyProps = parameters,
            OrderByParams = parameters,
            PaginationParams = parameters,
        };

    public static implicit operator FindManyPaginationServiceParams(
        IndexTreatmentsParams parameters)
        => new()
        {
            CountProps = parameters,
            PaginationParams = parameters,
        };
}