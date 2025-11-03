using ITControl.Presentation.Shared.Responses;

namespace ITControl.Presentation.KnowledgeBases.Responses;

public class FindOneKnowledgeBasesResponse
{
    public Guid? Id { get; set; }
    public string? Title { get; set; } = string.Empty;
    public string? Content { get; set; } = string.Empty;
    public TimeOnly? EstimatedTime { get; set; }
    public TranslatableField? Reason { get; set; } = null!;
    public Guid? UserId { get; set; }
    public FindOneKnowledgeBasesUserResponse? User { get; set; }
}
