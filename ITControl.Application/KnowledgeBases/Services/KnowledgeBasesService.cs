using ITControl.Application.KnowledgeBases.Interfaces;
using ITControl.Application.KnowledgeBases.Params;
using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Tools;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.KnowledgeBases.Entities;
using ITControl.Domain.Shared.Exceptions;

namespace ITControl.Application.KnowledgeBases.Services;

public class KnowledgeBasesService(
    IUnitOfWork unitOfWork) : IKnowledgeBasesService
{
    public async Task<KnowledgeBase> FindOneAsync(
        FindOneKnowledgeBasesServiceParams @params)
    {
        return await unitOfWork
            .KnowledgeBasesRepository
            .FindOneAsync(@params) 
               ?? throw new NotFoundException(
                   Errors.KnowledgeBaseNotFound);
    }

    public async Task<IEnumerable<KnowledgeBase>> FindManyAsync(
        FindManyKnowledgeBasesServiceParams @params)
    {
        return await unitOfWork
            .KnowledgeBasesRepository
            .FindManyAsync(
            @params.FindManyParams, 
            @params.OrderByParams, 
            @params.PaginationParams);
    }

    public async Task<PaginationResponse?> FindManyPaginationAsync(
        FindManyPaginationKnowledgeBasesServiceParams @params)
    {
        var (page, size) = @params;
        if (page == null || size == null) 
            return null;
        var count = await unitOfWork
            .KnowledgeBasesRepository
            .CountAsync(@params.CountParams);
        var pagination = Pagination.Build(page, size, count);

        return pagination;
    }

    public async Task<KnowledgeBase> CreateAsync(
        CreateKnowledgeBasesServiceParams @params)
    {
        using var transaction = unitOfWork.BeginTransaction;
        var knowledgeBase = new KnowledgeBase(@params.Params);
        await unitOfWork.KnowledgeBasesRepository
            .CreateAsync(knowledgeBase);
        await unitOfWork.Commit(transaction);

        return knowledgeBase;
    }

    public async Task UpdateAsync(
        UpdateKnowledgeBasesServiceParams @params)
    {
        var knowledgeBase = await FindOneAsync(@params);
        knowledgeBase.Update(@params.Params);
        using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.KnowledgeBasesRepository.Update(knowledgeBase);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(
        DeleteKnowledgeBasesServiceParams @params)
    {
        var knowledgeBase = await FindOneAsync(@params);
        using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.KnowledgeBasesRepository.Delete(knowledgeBase);
        await unitOfWork.Commit(transaction);
    }
}
