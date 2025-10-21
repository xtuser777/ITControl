using ITControl.Application.KnowledgeBases.Params;
using ITControl.Communication.KnowledgeBases.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.KnowledgeBases.Params;

public record UpdateKnowledgeBasesParams
{
    [FromRoute]
    public Guid Id { get; set; }

    [FromBody]
    public UpdateKnowledgeBasesRequest Request { get; set; } = new();

    public static implicit operator UpdateKnowledgeBasesServiceParams(
        UpdateKnowledgeBasesParams request)
        => new()
        {
            Id = request.Id,
            Params = request.Request
        };
}
