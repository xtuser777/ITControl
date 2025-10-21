namespace ITControl.Application.KnowledgeBases.Params;

public record DeleteKnowledgeBasesServiceParams
{
    public Guid Id { get; set; }

    public static implicit operator FindOneKnowledgeBasesServiceParams(
        DeleteKnowledgeBasesServiceParams model)
        => new()
        {
            Id = model.Id,
        };
}
