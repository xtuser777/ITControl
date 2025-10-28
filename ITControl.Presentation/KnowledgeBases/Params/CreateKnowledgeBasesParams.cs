using ITControl.Application.Shared.Params;
using ITControl.Presentation.KnowledgeBases.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.KnowledgeBases.Params;

public record CreateKnowledgeBasesParams
{
    [FromBody]
    public CreateKnowledgeBasesRequest Request { get; set; } = new();

    public static implicit operator CreateServiceParams(
        CreateKnowledgeBasesParams request)
        => new()
        {
            Params = request.Request
        };
}
