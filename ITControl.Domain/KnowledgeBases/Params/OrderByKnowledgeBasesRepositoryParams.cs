using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.KnowledgeBases.Params;

public record OrderByKnowledgeBasesRepositoryParams :
    OrderByRepositoryParams
{
    public string? Title { get; set; } = null;
    public string? Content { get; set; } = null;
    public string? EstimatedTime { get; set; } = null;
    public string? Reason { get; set; } = null;
    public string? User { get; set; } = null;
}
