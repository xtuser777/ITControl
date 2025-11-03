using ITControl.Application.Shared.Params;
using ITControl.Presentation.KnowledgeBases.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.KnowledgeBases.Params;

public record UpdateKnowledgeBasesParams
{
    [FromRoute]
    public Guid Id { get; set; }

    [FromBody]
    public UpdateKnowledgeBasesRequest Request { get; set; } = new();

    public static implicit operator UpdateServiceParams(
        UpdateKnowledgeBasesParams request)
        => new()
        {
            Id = request.Id,
            Props = request.Request
        };
}
