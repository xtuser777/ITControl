using ITControl.Domain.KnowledgeBases.Params;

namespace ITControl.Application.KnowledgeBases.Params;

public record FindOneKnowledgeBasesServiceParams
{
    public Guid Id { get; set; }
    public IncludesKnowledgeBasesParams? Includes { get; set; }

    public static implicit operator FindOneKnowledgeBasesRepositoryParams(
        FindOneKnowledgeBasesServiceParams serviceParams)
        => new()
        {
            Id = serviceParams.Id,
            Includes = serviceParams.Includes,
        };
}
