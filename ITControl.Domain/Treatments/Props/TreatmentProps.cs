using ITControl.Domain.Calls.Entities;
using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Treatments.Enums;
using ITControl.Domain.Users.Entities;

namespace ITControl.Domain.Treatments.Props;

public class TreatmentProps : Entity
{
    public string? Description { get; set; }
    public TreatmentStatus? Status { get; set; }
    public TreatmentType? Type { get; set; }
    public string? Observation { get; set; }
    public string? ExternalProtocol { get; set; }
    public Guid? CallId { get; set; }
    public Guid? UserId { get; set; }
    public string? Protocol { get; set; }
    public DateOnly? StartedAt { get; set; }
    public TimeOnly? StartedIn { get; set; }
    public DateOnly? EndedAt { get; set; }
    public TimeOnly? EndedIn { get; set; }
    public Call? Call { get; set; }
    public User? User { get; set; }
}