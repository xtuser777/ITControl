namespace ITControl.Domain.KnowledgeBases.Params;

public record FindOneKnowledgeBasesRepositoryParams
{
    public Guid Id { get; set; }
    public IncludesKnowledgeBasesParams? Includes { get; set; } = null;

    public void Deconstruct(
        out Guid id,
        out IncludesKnowledgeBasesParams? includes
    )
    {
        id = Id;
        includes = Includes;
    }
}
