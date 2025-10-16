namespace ITControl.Domain.KnowledgeBases.Params;

public record CountKnowledgeBasesRepositoryParams : FindManyKnowledgeBasesRepositoryParams
{
    public Guid? Id { get; set; } = null;
}
