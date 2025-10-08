using ITControl.Communication.Shared.Requests;
using ITControl.Communication.Shared.Utils;
using ITControl.Domain.Treatments.Enums;
using ITControl.Domain.Treatments.Params;

namespace ITControl.Communication.Treatments.Requests;

public class FindManyTreatmentsRequest : PageableRequest
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
    public string? OrderByDescription { get; set; }
    public string? OrderByProtocol { get; set; }
    public string? OrderByStartedAt { get; set; }
    public string? OrderByEndedAt { get; set; }
    public string? OrderByStartedIn { get; set; }
    public string? OrderByEndedIn { get; set; }
    public string? OrderByStatus { get; set; }
    public string? OrderByType { get; set; }
    public string? OrderByObservation { get; set; }
    public string? OrderByExternalProtocol { get; set; }
    public string? OrderByCall { get; set; }
    public string? OrderByUser { get; set; }

    public static implicit operator FindManyTreatmentsRepositoryParams(FindManyTreatmentsRequest request) =>
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
            OrderByDescription = request.OrderByDescription,
            OrderByProtocol = request.OrderByProtocol,
            OrderByStartedAt = request.OrderByStartedAt,
            OrderByEndedAt = request.OrderByEndedAt,
            OrderByStartedIn = request.OrderByStartedIn,
            OrderByEndedIn = request.OrderByEndedIn,
            OrderByStatus = request.OrderByStatus,
            OrderByType = request.OrderByType,
            OrderByObservation = request.OrderByObservation,
            OrderByExternalProtocol = request.OrderByExternalProtocol,
            OrderByCall = request.OrderByCall,
            OrderByUser = request.OrderByUser,
            Page = request.Page is null ? null : int.Parse(request.Page),
            Size = request.Size is null ? null : int.Parse(request.Size)
        };

    public static implicit operator CountTreatmentsRepositoryParams(FindManyTreatmentsRequest request) =>
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
}
