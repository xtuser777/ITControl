using ITControl.Application.Pages.Interfaces;
using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Tools;
using ITControl.Communication.Pages.Requests;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Exceptions;
using ITControl.Domain.Pages.Entities;
using ITControl.Infrastructure.Pages.Repositories;

namespace ITControl.Application.Pages.Services;

public class PagesService(IUnitOfWork unitOfWork) : IPagesService
{
    public async Task<IEnumerable<Page>> FindManyAsync(FindManyPagesRequest request)
    {
        return await unitOfWork.PagesRepository.FindManyAsync((FindManyPagesRepositoryParams)request);
    }

    public async Task<PaginationResponse?> FindManyPaginationAsync(FindManyPagesRequest request)
    {
        if (request.Page == null || request.Size == null) return null;
        
        var count = await unitOfWork.PagesRepository.CountAsync((CountPagesRepositoryParams)request);
        
        var pagination = Pagination.Build(request.Page, request.Size, count);
        
        return pagination;
    }

    public async Task<Page> FindOneAsync(Guid id)
    {
        return await unitOfWork
            .PagesRepository
            .FindOneAsync(new FindOnePagesRepositoryParams() { Id = id }) 
               ?? throw new NotFoundException(Errors.PAGE_NOT_FOUND);
    }

    public async Task<Page?> CreateAsync(Page page)
    {
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.PagesRepository.CreateAsync(page);
        await unitOfWork.Commit(transaction);
        
        return page;
    }

    public async Task UpdateAsync(Guid id, UpdatePageParams @params)
    {
        var page = await FindOneAsync(id);
        page.Update(@params);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.PagesRepository.Update(page);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(Guid id)
    {
        var page = await FindOneAsync(id);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.PagesRepository.Delete(page);
        await unitOfWork.Commit(transaction);
    }
}