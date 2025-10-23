using ITControl.Domain.Shared.Params2;
using ITControl.Domain.Treatments.Enums;

namespace ITControl.Domain.Treatments.Params;

public record UpdateTreatmentParams : UpdateEntityParams
{
    public string? Description { get; init; } = null;
    public string? Protocol { get; init; } = null;
    public DateOnly? StartedAt { get; init; } = null;
    public DateOnly? EndedAt { get; init; } = null;
    public TimeOnly? StartedIn { get; init; } = null;
    public TimeOnly? EndedIn { get; init; } = null;
    public TreatmentStatus? Status { get; init; } = null;
    public TreatmentType? Type { get; init; } = null;
    public string? Observation { get; init; } = null;
    public string? ExternalProtocol { get; init; } = null;
    public Guid? CallId { get; init; } = null;   
    public Guid? UserId { get; init; } = null;
}
