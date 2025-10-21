using ITControl.Domain.KnowledgeBases.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Communication.KnowledgeBases.Requests;

public record OrderByKnowledgeBasesRequest
{
    [FromHeader(Name = "X-Order-By-Title")]
    public string? Title { get; set; }

    [FromHeader(Name = "X-Order-By-Content")]
    public string? Content { get; set; }
    
    [FromHeader(Name = "X-Order-By-Estimated-Time")]
    public string? EstimatedTime { get; set; }
    
    [FromHeader(Name = "X-Order-By-Reason")]
    public string? Reason { get; set; }
    
    [FromHeader(Name = "X-Order-By-User")]
    public string? User { get; set; }

    public static implicit operator OrderByKnowledgeBasesRepositoryParams(
        OrderByKnowledgeBasesRequest request) =>
        new()
        {
            Title = request.Title,
            Content = request.Content,
            EstimatedTime = request.EstimatedTime,
            Reason = request.Reason,
            User = request.User,
        };
}
