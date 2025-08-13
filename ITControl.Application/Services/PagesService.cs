using ITControl.Application.Interfaces;
using ITControl.Application.Tools;
using ITControl.Communication.Pages.Requests;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Entities;
using ITControl.Domain.Exceptions;

namespace ITControl.Application.Services;

public class PagesService(IUnitOfWork unitOfWork) : IPagesService
{
    public async Task<IEnumerable<Page>> FindMany(FindManyPagesRequest request)
    {
        int? page = request.Page != null ? int.Parse(request.Page) : null;
        int? size = request.Size != null ? int.Parse(request.Size) : null;
        var pages = await unitOfWork.PagesRepository.FindManyAsync(
            name: request.Name,
            orderByName: request.OrderByName,
            page,
            size
        );
        
        return pages;
    }

    public async Task<PaginationResponse?> FindManyPagination(FindManyPagesRequest request)
    {
        if (request.Page == null || request.Size == null) return null;
        
        var count = await unitOfWork.PagesRepository.CountAsync(name: request.Name);
        
        var pagination = Pagination.Build(request.Page, request.Size, count);
        
        return pagination;
    }

    public async Task<Page?> FindOne(Guid id)
    {
        var page = await unitOfWork.PagesRepository.FindOneAsync(id: id);
        
        return page;
    }

    private async Task<Page> FindOneOrThrow(Guid id)
    {
        var page = await FindOne(id);
        if (page == null)
            throw new NotFoundException("Page not found");
        
        return page;
    }

    public async Task<Page?> Create(CreatePagesRequest request)
    {
        await CheckConflicts(name: request.Name);
        var page = Page.Create(name: request.Name);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.PagesRepository.CreateAsync(page);
        await unitOfWork.Commit(transaction);
        
        return page;
    }

    public async Task Update(Guid id, UpdatePagesRequest request)
    {
        await CheckConflicts(id, request.Name);
        var page = await FindOneOrThrow(id);
        page.Update(name: request.Name);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.PagesRepository.UpdateAsync(page);
        await unitOfWork.Commit(transaction);
    }

    public async Task Delete(Guid id)
    {
        var page = await FindOneOrThrow(id);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.PagesRepository.DeleteAsync(page);
        await unitOfWork.Commit(transaction);
    }

    private async Task CheckConflicts(Guid? id = null, string? name = null)
    {
        var messages = new List<string>();
        
        if (name != null)
            await CheckNameConflict(id, name, messages);
        
        if (messages.Count > 0)
            throw new ConflictException(string.Join(", ", messages));
    }

    private async Task CheckNameConflict(Guid? id, string name, List<string> messages)
    {
        var exists = id != null 
            ? await unitOfWork.PagesRepository.ExclusiveAsync((Guid)id, name) 
            : await unitOfWork.PagesRepository.ExistAsync(name: name);

        if (exists)
        {
            messages.Add("Page with this name already exists");
        }
    }
}