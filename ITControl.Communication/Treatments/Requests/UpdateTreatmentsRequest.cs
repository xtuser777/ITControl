using ITControl.Domain.Shared.Messages;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Treatments.Requests;

public class UpdateTreatmentsRequest
{
    [MaxLength(100, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MAX_LENGTH")]
    public string? Description { get; set; }
    public DateOnly? StartedAt { get; set; }
    public DateOnly? EndedAt { get; set; }
    public TimeOnly? StartedIn { get; set; }
    public TimeOnly? EndedIn { get; set; }
    public string? Status { get; set; }
    public string? Type { get; set; }
    
    [MaxLength(255, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MAX_LENGTH")]
    public string? Observation { get; set; }
    
    [MaxLength(50, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MAX_LENGTH")]
    public string? ExternalProtocol { get; set; }
    public Guid? CallId { get; set; }
    public Guid? UserId { get; set; }
}
