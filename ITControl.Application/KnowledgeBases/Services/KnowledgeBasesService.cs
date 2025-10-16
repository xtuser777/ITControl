using ITControl.Application.KnowledgeBases.Interfaces;
using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Tools;
using ITControl.Communication.KnowledgeBases.Requests;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.KnowledgeBases.Entities;
using ITControl.Domain.Shared.Exceptions;

namespace ITControl.Application.KnowledgeBases.Services;

public class KnowledgeBasesService(
    IUnitOfWork unitOfWork) : IKnowledgeBasesService
{
    public async Task<KnowledgeBase> FindOneAsync(FindOneKnowledgeBasesRequest request)
    {
        return await unitOfWork.KnowledgeBasesRepository.FindOneAsync(request) 
               ?? throw new NotFoundException(Errors.KnowledgeBaseNotFound);
    }

    public async Task<IEnumerable<KnowledgeBase>> FindManyAsync(
        FindManyKnowledgeBasesRequest request,
        OrderByKnowledgeBasesRequest orderByKnowledgeBasesRequest)
    {
        return await unitOfWork.KnowledgeBasesRepository.FindManyAsync(
            request, orderByKnowledgeBasesRequest, request);
    }

    public async Task<PaginationResponse?> FindManyPaginationAsync(FindManyKnowledgeBasesRequest request)
    {
        if (request.Page == null || request.Size == null) 
            return null;
        var count = await unitOfWork.KnowledgeBasesRepository.CountAsync(request);
        var pagination = Pagination.Build(request.Page, request.Size, count);

        return pagination;
    }

    public async Task<KnowledgeBase> CreateAsync(CreateKnowledgeBasesRequest request)
    {
        using var transaction = unitOfWork.BeginTransaction;
        var knowledgeBase = new KnowledgeBase(request);
        await unitOfWork.KnowledgeBasesRepository.CreateAsync(knowledgeBase);
        await unitOfWork.Commit(transaction);

        return knowledgeBase;
    }

    public async Task UpdateAsync(Guid id, UpdateKnowledgeBasesRequest request)
    {
        var knowledgeBase = await FindOneAsync(new () { Id = id });
        knowledgeBase.Update(request);
        using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.KnowledgeBasesRepository.Update(knowledgeBase);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(Guid id)
    {
        var knowledgeBase = await FindOneAsync(new() { Id = id });
        using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.KnowledgeBasesRepository.Delete(knowledgeBase);
        await unitOfWork.Commit(transaction);
    }
}
