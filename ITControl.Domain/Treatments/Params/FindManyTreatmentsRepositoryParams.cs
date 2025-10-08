using ITControl.Domain.Treatments.Enums;

namespace ITControl.Domain.Treatments.Params;

public class FindManyTreatmentsRepositoryParams
{
    public string? Description { get; set; } = null;
    public string? Protocol { get; set; } = null;
    public DateOnly? StartedAt { get; set; } = null;
    public DateOnly? EndedAt { get; set; } = null;
    public TimeOnly? StartedIn { get; set; } = null;
    public TimeOnly? EndedIn { get; set; } = null;
    public TreatmentStatus? Status { get; set; } = null;
    public TreatmentType? Type { get; set; } = null;
    public string? Observation { get; set; } = null;
    public string? ExternalProtocol { get; set; } = null;
    public Guid? CallId { get; set; } = null;
    public Guid? UserId { get; set; } = null;
    public string? OrderByDescription { get; set; } = null;
    public string? OrderByProtocol { get; set; } = null;
    public string? OrderByStartedAt { get; set; } = null;
    public string? OrderByEndedAt { get; set; } = null;
    public string? OrderByStartedIn { get; set; } = null;
    public string? OrderByEndedIn { get; set; } = null;
    public string? OrderByStatus { get; set; } = null;
    public string? OrderByType { get; set; } = null;
    public string? OrderByObservation { get; set; } = null;
    public string? OrderByExternalProtocol { get; set; } = null;
    public string? OrderByCall { get; set; } = null;
    public string? OrderByUser { get; set; } = null;
    public int? Page { get; set; } = null;
    public int? Size { get; set; } = null;

    public static implicit operator CountTreatmentsRepositoryParams(FindManyTreatmentsRepositoryParams paramsIn) =>
        new()
        {
            Description = paramsIn.Description,
            Protocol = paramsIn.Protocol,
            StartedAt = paramsIn.StartedAt,
            EndedAt = paramsIn.EndedAt,
            StartedIn = paramsIn.StartedIn,
            EndedIn = paramsIn.EndedIn,
            Status = paramsIn.Status,
            Type = paramsIn.Type,
            Observation = paramsIn.Observation,
            ExternalProtocol = paramsIn.ExternalProtocol,
            CallId = paramsIn.CallId,
            UserId = paramsIn.UserId
        };

    public void Deconstruct(out int? page, out int? size)
    {
        page = Page;
        size = Size;
    }
}
