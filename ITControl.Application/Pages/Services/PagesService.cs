using ITControl.Application.Pages.Interfaces;
using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Tools;
using ITControl.Communication.Pages.Requests;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Pages.Entities;
using ITControl.Domain.Shared.Exceptions;

namespace ITControl.Application.Pages.Services;

public class PagesService(IUnitOfWork unitOfWork) : IPagesService
{
    public async Task<IEnumerable<Page>> FindManyAsync(
        FindManyPagesRequest findManyRequest,
        OrderByPagesRequest orderByRequest)
    {
        return await unitOfWork.PagesRepository.FindManyAsync(
            findManyRequest, orderByRequest, findManyRequest);
    }

    public async Task<PaginationResponse?> FindManyPaginationAsync(FindManyPagesRequest request)
    {
        if (request.Page == null || request.Size == null) return null;
        
        var count = await unitOfWork.PagesRepository.CountAsync(request);
        
        var pagination = Pagination.Build(request.Page, request.Size, count);
        
        return pagination;
    }

    public async Task<Page> FindOneAsync(FindOnePagesRequest request)
    {
        return await unitOfWork
            .PagesRepository
            .FindOneAsync(request) 
               ?? throw new NotFoundException(Errors.PAGE_NOT_FOUND);
    }

    public async Task<Page?> CreateAsync(CreatePagesRequest request)
    {
        await using var transaction = unitOfWork.BeginTransaction;
        var page = new Page(request);
        await unitOfWork.PagesRepository.CreateAsync(page);
        await unitOfWork.Commit(transaction);
        
        return page;
    }

    public async Task UpdateAsync(Guid id, UpdatePagesRequest request)
    {
        var page = await FindOneAsync(new() { Id = id });
        page.Update(request);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.PagesRepository.Update(page);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(Guid id)
    {
        var page = await FindOneAsync(new() { Id = id });
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.PagesRepository.Delete(page);
        await unitOfWork.Commit(transaction);
    }
}