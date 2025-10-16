using ITControl.Communication.KnowledgeBases.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.KnowledgeBases.Headers;

public record OrderByKnowledgeBasesHeaders
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

    public static implicit operator OrderByKnowledgeBasesRequest(OrderByKnowledgeBasesHeaders headers) =>
        new()
        {
            Title = headers.Title,
            Content = headers.Content,
            EstimatedTime = headers.EstimatedTime,
            Reason = headers.Reason,
            User = headers.User,
        };
}
