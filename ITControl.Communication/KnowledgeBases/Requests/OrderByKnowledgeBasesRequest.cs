using ITControl.Domain.KnowledgeBases.Params;

namespace ITControl.Communication.KnowledgeBases.Requests;

public record OrderByKnowledgeBasesRequest
{
    public string? Title { get; set; }
    public string? Content { get; set; }
    public string? EstimatedTime { get; set; }
    public string? Reason { get; set; }
    public string? User { get; set; }

    public static implicit operator OrderByKnowledgeBasesRepositoryParams(OrderByKnowledgeBasesRequest request) =>
        new()
        {
            Title = request.Title,
            Content = request.Content,
            EstimatedTime = request.EstimatedTime,
            Reason = request.Reason,
            User = request.User,
        };
}
