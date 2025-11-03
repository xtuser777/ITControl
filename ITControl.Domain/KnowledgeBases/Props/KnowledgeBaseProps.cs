using ITControl.Domain.Calls.Enums;
using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Users.Entities;

namespace ITControl.Domain.KnowledgeBases.Props;

public class KnowledgeBaseProps : Entity
{
    public string? Title { get; set; }
    public string? Content { get; set; }
    public TimeOnly? EstimatedTime { get; set; }
    public CallReason? Reason { get; set; }
    public Guid? UserId { get; set; }
    public User? User { get; set; }
}