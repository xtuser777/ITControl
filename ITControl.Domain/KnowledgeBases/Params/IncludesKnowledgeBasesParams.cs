using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.KnowledgeBases.Params;

public record IncludesKnowledgeBasesParams : IncludesParams
{
    public bool? User { get; set; }
}
