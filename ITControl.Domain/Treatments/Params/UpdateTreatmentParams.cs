using ITControl.Domain.Shared.Params;
using ITControl.Domain.Treatments.Enums;

namespace ITControl.Domain.Treatments.Params;

public record UpdateTreatmentParams : UpdateEntityParams
{
    public string? Description { get; init; }
    public string? Protocol { get; init; }
    public DateOnly? StartedAt { get; init; }
    public DateOnly? EndedAt { get; init; }
    public TimeOnly? StartedIn { get; init; }
    public TimeOnly? EndedIn { get; init; }
    public TreatmentStatus? Status { get; init; }
    public TreatmentType? Type { get; init; }
    public string? Observation { get; init; }
    public string? ExternalProtocol { get; init; }
    public Guid? CallId { get; init; }   
    public Guid? UserId { get; init; }
}
