namespace ITControl.Domain.KnowledgeBases.Params;

public record CountKnowledgeBasesParams : 
    FindManyKnowledgeBasesParams
{
    public Guid? Id { get; set; } = null;
}
