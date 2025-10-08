using ITControl.Domain.Treatments.Enums;

namespace ITControl.Domain.Treatments.Params;

public class CountTreatmentsRepositoryParams
{
    public Guid? Id { get; set; } = null;
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
}
