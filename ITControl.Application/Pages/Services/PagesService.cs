using ITControl.Application.Pages.Interfaces;
using ITControl.Application.Shared.Params;
using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Tools;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Pages.Entities;
using ITControl.Domain.Pages.Params;
using ITControl.Domain.Shared.Exceptions;

namespace ITControl.Application.Pages.Services;

public class PagesService(IUnitOfWork unitOfWork) : IPagesService
{
    public async Task<Page> FindOneAsync(
        FindOneServiceParams parameters)
    {
        return await unitOfWork
            .PagesRepository
            .FindOneAsync(parameters)
               ?? throw new NotFoundException(Errors.PAGE_NOT_FOUND);
    }

    public async Task<IEnumerable<Page>> FindManyAsync(
        FindManyServiceParams parameters)
    {
        return await unitOfWork.PagesRepository.FindManyAsync(parameters);
    }

    public async Task<PaginationResponse?> FindManyPaginationAsync(
        FindManyPaginationServiceParams parameters)
    {
        var count = await unitOfWork.PagesRepository
            .CountAsync(parameters.CountParams);
        var pagination = 
            Pagination.Build(parameters.PaginationParams, count);
        return pagination;
    }

    public async Task<Page?> CreateAsync(
        CreateServiceParams parameters)
    {
        await using var transaction = unitOfWork.BeginTransaction;
        var page = new Page((PageParams)parameters.Params);
        await unitOfWork.PagesRepository.CreateAsync(page);
        await unitOfWork.Commit(transaction);
        
        return page;
    }

    public async Task UpdateAsync(
        UpdateServiceParams parameters)
    {
        var page = await FindOneAsync(parameters);
        page.Update((UpdatePageParams)parameters.Params);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.PagesRepository.Update(page);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(
        DeleteServiceParams parameters)
    {
        var page = await FindOneAsync(parameters);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.PagesRepository.Delete(page);
        await unitOfWork.Commit(transaction);
    }
}