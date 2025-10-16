using ITControl.Domain.Calls.Enums;

namespace ITControl.Domain.KnowledgeBases.Params;

public record KnowledgeBaseParams
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public TimeOnly EstimatedTime { get; set; }
    public CallReason Reason { get; set; }
    public Guid UserId { get; set; }
}
