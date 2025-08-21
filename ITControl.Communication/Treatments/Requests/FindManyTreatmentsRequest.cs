using ITControl.Communication.Shared.Requests;

namespace ITControl.Communication.Treatments.Requests;

public class FindManyTreatmentsRequest : PageableRequest
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
    public string? OrderByDescription { get; set; }
    public string? OrderByProtocol { get; set; }
    public string? OrderByStartedAt { get; set; }
    public string? OrderByEndedAt { get; set; }
    public string? OrderByStartedIn { get; set; }
    public string? OrderByEndedIn { get; set; }
    public string? OrderByStatus { get; set; }
    public string? OrderByType { get; set; }
    public string? OrderByObservation { get; set; }
    public string? OrderByExternalProtocol { get; set; }
    public string? OrderByCall { get; set; }
    public string? OrderByUser { get; set; }
}
