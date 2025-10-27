using ITControl.Application.Shared.Params;
using ITControl.Domain.KnowledgeBases.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.KnowledgeBases.Params;

public record ShowKnowledgeBasesParams
{
    [FromRoute]
    public Guid Id { get; set; }

    [FromQuery]
    public bool? IncludeUser { get; set; } = true;

    public static implicit operator FindOneServiceParams(
        ShowKnowledgeBasesParams show)
        => new()
        {
            Id = show.Id,
            Includes = new IncludesKnowledgeBasesParams
            {
                User = show.IncludeUser,
            }
        };
}
