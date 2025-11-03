using ITControl.Presentation.Shared.Responses;

namespace ITControl.Presentation.Treatments.Responses;

public class FindOneTreatmentsResponse
{
    public Guid? Id { get; set; }
    public string? Description { get; set; } = string.Empty;
    public string? Protocol { get; set; } = string.Empty;
    public DateOnly? StartedAt { get; set; }
    public DateOnly? EndedAt { get; set; }
    public TimeOnly? StartedIn { get; set; }
    public TimeOnly? EndedIn { get; set; }
    public TranslatableField Status { get; set; } = null!;
    public TranslatableField Type { get; set; } = null!;
    public string? Observation { get; set; } = string.Empty;
    public string? ExternalProtocol { get; set; } = string.Empty;
    public Guid? CallId { get; set; }
    public Guid? UserId { get; set; }
    public FindOneTreatmentsCallResponse? Call { get; set; }
    public FindOneTreatmentsUserResponse? User { get; set; }
}
