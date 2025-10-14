using ITControl.Application.KnowledgeBases.Interfaces;
using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Tools;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Shared.Exceptions;
using ITControl.Domain.KnowledgeBases.Entities;
using ITControl.Domain.KnowledgeBases.Interfaces;
using ITControl.Infrastructure.KnowledgeBases.Repositories;

namespace ITControl.Application.KnowledgeBases.Services;

public class KnowledgeBasesService(
    IUnitOfWork unitOfWork) : IKnowledgeBasesService
{
    public async Task<KnowledgeBase> FindOneAsync(IFindOneKnowledgeBasesRepositoryParams @params)
    {
        return await unitOfWork.KnowledgeBasesRepository.FindOneAsync(@params) 
               ?? throw new NotFoundException(Errors.KnowledgeBaseNotFound);
    }

    public async Task<IEnumerable<KnowledgeBase>> FindManyAsync(IFindManyKnowledgeBasesRepositoryParams @params)
    {
        return await unitOfWork.KnowledgeBasesRepository.FindManyAsync(@params);
    }

    public async Task<PaginationResponse?> FindManyPaginationAsync(IFindManyKnowledgeBasesRepositoryParams @params)
    {
        if (!@params.Page.HasValue || !@params.Size.HasValue) return null;
        var countParams = (CountKnowledgeBasesRepositoryParams)
            (@params as FindManyKnowledgeBasesRepositoryParams)!;
        var count = await unitOfWork.KnowledgeBasesRepository.CountAsync(countParams);
        var pagination = Pagination.Build(@params.Page.Value.ToString(), @params.Size.Value.ToString(), count);

        return pagination;
    }

    public async Task<KnowledgeBase> CreateAsync(KnowledgeBase knowledgeBase)
    {
        using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.KnowledgeBasesRepository.CreateAsync(knowledgeBase);
        await unitOfWork.Commit(transaction);

        return knowledgeBase;
    }

    public async Task UpdateAsync(Guid id, UpdateKnowledgeBaseParams @params)
    {
        var knowledgeBase = await FindOneAsync(
            new FindOneKnowledgeBasesRepositoryParams
            {
                Id = id,
                IncludeUser = false
            });
        knowledgeBase.Update(@params);
        using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.KnowledgeBasesRepository.Update(knowledgeBase);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(Guid id)
    {
        var knowledgeBase = await FindOneAsync(
            new FindOneKnowledgeBasesRepositoryParams
            {
                Id = id,
                IncludeUser = false
            });
        using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.KnowledgeBasesRepository.Delete(knowledgeBase);
        await unitOfWork.Commit(transaction);
    }
}
