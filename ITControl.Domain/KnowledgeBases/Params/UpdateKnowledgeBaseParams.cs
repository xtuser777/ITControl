using ITControl.Domain.Calls.Enums;

namespace ITControl.Domain.KnowledgeBases.Params;

public record UpdateKnowledgeBaseParams
{
    public string? Title { get; set; } = null;
    public string? Content { get; set; } = null;
    public TimeOnly? EstimatedTime { get; set; } = null;
    public CallReason? Reason { get; set; } = null;
    public Guid? UserId { get; set; } = null;

    internal void Deconstruct(
        out string? title,
        out string? content,
        out TimeOnly? estimatedTime,
        out CallReason? reason,
        out Guid? userId
    )
    {
        title = Title;
        content = Content;
        estimatedTime = EstimatedTime;
        reason = Reason;
        userId = UserId;
    }
}
