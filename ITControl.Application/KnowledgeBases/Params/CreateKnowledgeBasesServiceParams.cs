using ITControl.Domain.KnowledgeBases.Params;

namespace ITControl.Application.KnowledgeBases.Params;

public record CreateKnowledgeBasesServiceParams
{
    public KnowledgeBaseParams Params { get; set; } = new();
}
