using ITControl.Communication.Shared.Responses;

namespace ITControl.Communication.Treatments.Responses;

public class FindManyTreatmentsResponse
{
    public Guid Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Protocol { get; set; } = string.Empty;
    public DateOnly StartedAt { get; set; }
    public DateOnly? EndedAt { get; set; }
    public TimeOnly StartedIn { get; set; }
    public TimeOnly? EndedIn { get; set; }
    public TranslatableField Status { get; set; } = null!;
    public TranslatableField Type { get; set; } = null!;
    public string Observation { get; set; } = string.Empty;
    public string ExternalProtocol { get; set; } = string.Empty;
    public Guid CallId { get; set; }
    public Guid UserId { get; set; }
}
