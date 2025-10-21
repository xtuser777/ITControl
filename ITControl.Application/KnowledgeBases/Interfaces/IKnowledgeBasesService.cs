using ITControl.Application.KnowledgeBases.Params;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.KnowledgeBases.Entities;

namespace ITControl.Application.KnowledgeBases.Interfaces;

public interface IKnowledgeBasesService
{
    Task<KnowledgeBase> FindOneAsync(
        FindOneKnowledgeBasesServiceParams @params);
    Task<IEnumerable<KnowledgeBase>> FindManyAsync(
        FindManyKnowledgeBasesServiceParams @params);
    Task<PaginationResponse?> FindManyPaginationAsync(
        FindManyPaginationKnowledgeBasesServiceParams @params);
    Task<KnowledgeBase> CreateAsync(
        CreateKnowledgeBasesServiceParams @params);
    Task UpdateAsync(UpdateKnowledgeBasesServiceParams @params);
    Task DeleteAsync(DeleteKnowledgeBasesServiceParams @params);
}
