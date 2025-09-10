using ITControl.Communication.Shared.Responses;
using ITControl.Domain.KnowledgeBases.Entities;
using ITControl.Domain.KnowledgeBases.Interfaces;

namespace ITControl.Application.KnowledgeBases.Interfaces;

public interface IKnowledgeBasesService
{
    Task<KnowledgeBase> FindOneAsync(IFindOneKnowledgeBasesRepositoryParams @params);
    Task<IEnumerable<KnowledgeBase>> FindManyAsync(IFindManyKnowledgeBasesRepositoryParams @params);
    Task<PaginationResponse?> FindManyPaginationAsync(IFindManyKnowledgeBasesRepositoryParams @params);
    Task<KnowledgeBase> CreateAsync(KnowledgeBase knowledgeBase);
    Task UpdateAsync(Guid id, UpdateKnowledgeBaseParams @params);
    Task DeleteAsync(Guid id);
}
