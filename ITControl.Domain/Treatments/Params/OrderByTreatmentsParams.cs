using ITControl.Domain.Shared.Params2;

namespace ITControl.Domain.Treatments.Params;

public record OrderByTreatmentsParams : OrderByParams
{
    public string? Description { get; set; }
    public string? Protocol { get; set; }
    public string? StartedAt { get; set; }
    public string? EndedAt { get; set; }
    public string? StartedIn { get; set; }
    public string? EndedIn { get; set; }
    public string? Status { get; set; }
    public string? Type { get; set; }
    public string? Observation { get; set; }
    public string? ExternalProtocol { get; set; }
    public string? Call { get; set; }
    public string? User { get; set; }
}