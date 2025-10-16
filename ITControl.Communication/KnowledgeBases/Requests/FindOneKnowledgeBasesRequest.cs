using ITControl.Domain.KnowledgeBases.Params;

namespace ITControl.Communication.KnowledgeBases.Requests;

public record FindOneKnowledgeBasesRequest
{
    public Guid Id { get; set; }
    public bool? IncludeUser { get; set; } = null;

    public static implicit operator FindOneKnowledgeBasesRepositoryParams(FindOneKnowledgeBasesRequest request) =>
        new()
        {
            Id = request.Id,
            Includes = new IncludesKnowledgeBasesParams
            {
                User = request.IncludeUser
            }
        };
}
