using ITControl.Domain.Shared.Params2;
using ITControl.Domain.Treatments.Enums;

namespace ITControl.Domain.Treatments.Params;

public record FindManyTreatmentsParams : FindManyParams
{
    public string? Description { get; set; }
    public string? Protocol { get; set; }
    public DateOnly? StartedAt { get; set; }
    public DateOnly? EndedAt { get; set; }
    public TimeOnly? StartedIn { get; set; }
    public TimeOnly? EndedIn { get; set; }
    public TreatmentStatus? Status { get; set; }
    public TreatmentType? Type { get; set; }
    public string? Observation { get; set; }
    public string? ExternalProtocol { get; set; }
    public Guid? CallId { get; set; }
    public Guid? UserId { get; set; }
}
