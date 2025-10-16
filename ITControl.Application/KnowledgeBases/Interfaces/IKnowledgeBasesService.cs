using ITControl.Communication.KnowledgeBases.Requests;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.KnowledgeBases.Entities;

namespace ITControl.Application.KnowledgeBases.Interfaces;

public interface IKnowledgeBasesService
{
    Task<KnowledgeBase> FindOneAsync(FindOneKnowledgeBasesRequest request);
    Task<IEnumerable<KnowledgeBase>> FindManyAsync(
        FindManyKnowledgeBasesRequest request,
        OrderByKnowledgeBasesRequest orderByKnowledgeBasesRequest);
    Task<PaginationResponse?> FindManyPaginationAsync(FindManyKnowledgeBasesRequest request);
    Task<KnowledgeBase> CreateAsync(CreateKnowledgeBasesRequest request);
    Task UpdateAsync(Guid id, UpdateKnowledgeBasesRequest request);
    Task DeleteAsync(Guid id);
}
