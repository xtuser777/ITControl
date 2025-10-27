using ITControl.Application.Shared.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.KnowledgeBases.Params;

public record DeleteKnowledgeBasesParams
{
    [FromRoute]
    public Guid Id { get; set; }

    public static implicit operator DeleteServiceParams(
        DeleteKnowledgeBasesParams request)
        => new()
        {
            Id = request.Id
        };
}
