using ITControl.Domain.KnowledgeBases.Params;

namespace ITControl.Application.KnowledgeBases.Params;

public record UpdateKnowledgeBasesServiceParams
{
    public Guid Id { get; set; }
    public UpdateKnowledgeBaseParams Params { get; set; } = new();

    public static implicit operator FindOneKnowledgeBasesServiceParams(
        UpdateKnowledgeBasesServiceParams model)
        => new()
        {
            Id = model.Id,
        };
}
