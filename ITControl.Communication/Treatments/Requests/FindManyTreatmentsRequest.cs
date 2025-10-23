using ITControl.Communication.Shared.Requests;
using ITControl.Communication.Shared.Utils;
using ITControl.Domain.Treatments.Enums;
using ITControl.Domain.Treatments.Params;

namespace ITControl.Communication.Treatments.Requests;

public record FindManyTreatmentsRequest : FindManyRequest
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

    public static implicit operator FindManyTreatmentsParams(
        FindManyTreatmentsRequest request) =>
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
        FindManyTreatmentsRequest request) =>
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
