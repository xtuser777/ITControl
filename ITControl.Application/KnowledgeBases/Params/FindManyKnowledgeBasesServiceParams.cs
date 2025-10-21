using ITControl.Domain.KnowledgeBases.Params;
using ITControl.Domain.Shared.Params;

namespace ITControl.Application.KnowledgeBases.Params;

public record FindManyKnowledgeBasesServiceParams
{
    public FindManyKnowledgeBasesRepositoryParams FindManyParams { get; set; } = new();
    public OrderByKnowledgeBasesRepositoryParams OrderByParams { get; set; } = new();
    public PaginationParams PaginationParams { get; set; } = new();
}
