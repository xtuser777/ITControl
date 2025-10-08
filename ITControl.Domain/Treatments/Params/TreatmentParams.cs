using ITControl.Domain.Treatments.Enums;

namespace ITControl.Domain.Treatments.Params;

public class TreatmentParams
{
    public string Description { get; set; } = string.Empty;
    public string Protocol { get; set; } = string.Empty;
    public DateOnly StartedAt { get; set; }
    public DateOnly? EndedAt { get; set; }
    public TimeOnly StartedIn { get; set; }
    public TimeOnly? EndedIn { get; set; }
    public TreatmentStatus Status { get; set; }
    public TreatmentType Type { get; set; }
    public string Observation { get; set; } = string.Empty;
    public string ExternalProtocol { get; set; } = string.Empty;
    public Guid CallId { get; set; }
    public Guid UserId { get; set; }
}
