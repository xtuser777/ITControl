using ITControl.Application.Pages.Interfaces;
using ITControl.Application.Pages.Params;
using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Tools;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Pages.Entities;
using ITControl.Domain.Shared.Exceptions;

namespace ITControl.Application.Pages.Services;

public class PagesService(IUnitOfWork unitOfWork) : IPagesService
{
    public async Task<Page> FindOneAsync(FindOnePagesServiceParams @params)
    {
        return await unitOfWork
            .PagesRepository
            .FindOneAsync(@params)
               ?? throw new NotFoundException(Errors.PAGE_NOT_FOUND);
    }

    public async Task<IEnumerable<Page>> FindManyAsync(
        FindManyPagesServiceParams @params)
    {
        return await unitOfWork.PagesRepository.FindManyAsync(
            @params.FindManyParams,
            @params.OrderByParams,
            @params.PaginationParams);
    }

    public async Task<PaginationResponse?> FindManyPaginationAsync(
        FindManyPaginationPagesServiceParams @params)
    {
        if (@params.Page == null || @params.Size == null) return null;
        
        var count = await unitOfWork.PagesRepository.CountAsync(@params.CountParams);
        
        var pagination = Pagination.Build(@params.Page, @params.Size, count);
        
        return pagination;
    }

    public async Task<Page?> CreateAsync(CreatePagesServiceParams @params)
    {
        await using var transaction = unitOfWork.BeginTransaction;
        var page = new Page(@params.Params);
        await unitOfWork.PagesRepository.CreateAsync(page);
        await unitOfWork.Commit(transaction);
        
        return page;
    }

    public async Task UpdateAsync(UpdatePagesServiceParams @params)
    {
        var page = await FindOneAsync(@params);
        page.Update(@params.Params);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.PagesRepository.Update(page);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(DeletePagesServiceParams @params)
    {
        var page = await FindOneAsync(@params);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.PagesRepository.Delete(page);
        await unitOfWork.Commit(transaction);
    }
}