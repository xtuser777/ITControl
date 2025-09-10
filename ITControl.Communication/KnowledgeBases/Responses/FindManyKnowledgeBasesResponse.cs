namespace ITControl.Communication.KnowledgeBases.Responses;

public class FindManyKnowledgeBasesResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public TimeOnly EstimatedTime { get; set; }
    public string Reason { get; set; } = string.Empty;
    public Guid UserId { get; set; }
}
