using ITControl.Domain.Calls.Enums;
using ITControl.Domain.Shared.Params2;

namespace ITControl.Domain.KnowledgeBases.Params;

public record KnowledgeBaseParams : EntityParams
{
    public string Title { get; init; } = string.Empty;
    public string Content { get; init; } = string.Empty;
    public TimeOnly EstimatedTime { get; init; }
    public CallReason Reason { get; init; }
    public Guid UserId { get; init; }
}
