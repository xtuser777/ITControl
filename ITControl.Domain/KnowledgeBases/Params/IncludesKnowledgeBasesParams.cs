using ITControl.Domain.Shared.Params2;

namespace ITControl.Domain.KnowledgeBases.Params;

public record IncludesKnowledgeBasesParams : IncludesParams
{
    public bool? User { get; set; } = null;
}
