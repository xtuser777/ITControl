using ITControl.Domain.Calls.Enums;

namespace ITControl.Domain.KnowledgeBases.Params;

public record FindManyKnowledgeBasesRepositoryParams
{
    public string? Title { get; set; } = null;
    public string? Content { get; set; } = null;
    public TimeOnly? EstimatedTime { get; set; } = null;
    public CallReason? Reason { get; set; } = null;
    public Guid? UserId { get; set; } = null;
}
