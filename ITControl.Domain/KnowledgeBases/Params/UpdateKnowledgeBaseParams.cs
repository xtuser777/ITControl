using ITControl.Domain.Calls.Enums;
using ITControl.Domain.Shared.Params2;

namespace ITControl.Domain.KnowledgeBases.Params;

public record UpdateKnowledgeBaseParams : UpdateEntityParams
{
    public string? Title { get; init; }
    public string? Content { get; init; }
    public TimeOnly? EstimatedTime { get; init; }
    public CallReason? Reason { get; init; }
    public Guid? UserId { get; init; }

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
