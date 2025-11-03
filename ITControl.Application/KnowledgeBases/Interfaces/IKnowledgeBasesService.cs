using ITControl.Application.Shared.Params;
using ITControl.Domain.KnowledgeBases.Entities;
using ITControl.Domain.Shared.Entities;

namespace ITControl.Application.KnowledgeBases.Interfaces;

public interface IKnowledgeBasesService
{
    Task<KnowledgeBase> FindOneAsync(
        FindOneServiceParams parameters);
    Task<IEnumerable<KnowledgeBase>> FindManyAsync(
        FindManyServiceParams parameters);
    Task<PaginationModel?> FindManyPaginationAsync(
        FindManyPaginationServiceParams parameters);
    Task<KnowledgeBase> CreateAsync(
        CreateServiceParams parameters);
    Task UpdateAsync(
        UpdateServiceParams parameters);
    Task DeleteAsync(
        DeleteServiceParams parameters);
}
