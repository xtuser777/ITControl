namespace ITControl.Communication.Treatments.Requests;

public class CreateTreatmentsRequest
{
    public string Description { get; set; } = string.Empty;
    public DateOnly StartedAt { get; set; }
    public DateOnly? EndedAt { get; set; }
    public TimeOnly StartedIn { get; set; }
    public TimeOnly? EndedIn { get; set; }
    public string Status { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Observation { get; set; } = string.Empty;
    public string ExternalProtocol { get; set; } = string.Empty;
    public Guid CallId { get; set; }
    public Guid UserId { get; set; }
}
