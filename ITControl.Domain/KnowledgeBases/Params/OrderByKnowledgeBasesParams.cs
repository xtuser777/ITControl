using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.KnowledgeBases.Params;

public record OrderByKnowledgeBasesParams :
    OrderByParams
{
    public string? Title { get; set; } 
    public string? Content { get; set; } 
    public string? EstimatedTime { get; set; } 
    public string? Reason { get; set; } 
    public string? User { get; set; } 
}
