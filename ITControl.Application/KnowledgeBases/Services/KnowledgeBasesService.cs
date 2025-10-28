using ITControl.Application.KnowledgeBases.Interfaces;
using ITControl.Application.Shared.Params;
using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Tools;
using ITControl.Domain.Shared.Entities;
using ITControl.Domain.KnowledgeBases.Entities;
using ITControl.Domain.KnowledgeBases.Params;
using ITControl.Domain.Shared.Exceptions;

namespace ITControl.Application.KnowledgeBases.Services;

public class KnowledgeBasesService(
    IUnitOfWork unitOfWork) : IKnowledgeBasesService
{
    public async Task<KnowledgeBase> FindOneAsync(
        FindOneServiceParams parameters)
    {
        return await unitOfWork
            .KnowledgeBasesRepository
            .FindOneAsync(parameters) 
               ?? throw new NotFoundException(
                   Errors.KnowledgeBaseNotFound);
    }

    public async Task<IEnumerable<KnowledgeBase>> FindManyAsync(
        FindManyServiceParams parameters)
    {
        return await unitOfWork
            .KnowledgeBasesRepository
            .FindManyAsync(parameters);
    }

    public async Task<PaginationModel?> FindManyPaginationAsync(
        FindManyPaginationServiceParams parameters)
    {
        var count = await unitOfWork
            .KnowledgeBasesRepository
            .CountAsync(parameters.CountParams);
        var pagination = 
            Pagination.Build(parameters.PaginationParams, count);
        return pagination;
    }

    public async Task<KnowledgeBase> CreateAsync(
        CreateServiceParams parameters)
    {
        await using var transaction = unitOfWork.BeginTransaction;
        var knowledgeBase = 
            new KnowledgeBase((KnowledgeBaseParams)parameters.Params);
        await unitOfWork.KnowledgeBasesRepository
            .CreateAsync(knowledgeBase);
        await unitOfWork.Commit(transaction);

        return knowledgeBase;
    }

    public async Task UpdateAsync(
        UpdateServiceParams parameters)
    {
        var knowledgeBase = await FindOneAsync(parameters);
        knowledgeBase.Update(
            (UpdateKnowledgeBaseParams)parameters.Params);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.KnowledgeBasesRepository.Update(knowledgeBase);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(
        DeleteServiceParams parameters)
    {
        var knowledgeBase = await FindOneAsync(parameters);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.KnowledgeBasesRepository.Delete(knowledgeBase);
        await unitOfWork.Commit(transaction);
    }
}
