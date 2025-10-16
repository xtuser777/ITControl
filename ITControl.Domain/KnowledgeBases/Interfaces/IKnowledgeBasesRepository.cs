using ITControl.Domain.KnowledgeBases.Entities;
using ITControl.Domain.KnowledgeBases.Params;
using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.KnowledgeBases.Interfaces;

public interface IKnowledgeBasesRepository
{
    Task<KnowledgeBase?> FindOneAsync(
        FindOneKnowledgeBasesRepositoryParams @params);
    Task<IEnumerable<KnowledgeBase>> FindManyAsync(
        FindManyKnowledgeBasesRepositoryParams findManyParams,
        OrderByKnowledgeBasesRepositoryParams orderByParams,
        PaginationParams paginationParams);
    Task CreateAsync(KnowledgeBase knowledgeBase);
    void Update(KnowledgeBase knowledgeBase);
    void Delete(KnowledgeBase knowledgeBase);
    Task<int> CountAsync(CountKnowledgeBasesRepositoryParams @params);
    Task<bool> ExistsAsync(ExistsKnowledgeBasesRepositoryParams @params);
}
