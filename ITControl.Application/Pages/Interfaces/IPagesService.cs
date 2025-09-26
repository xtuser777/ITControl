using ITControl.Communication.Pages.Requests;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Pages.Entities;

namespace ITControl.Application.Pages.Interfaces;

public interface IPagesService
{
    Task<IEnumerable<Page>> FindManyAsync(FindManyPagesRequest request);
    Task<PaginationResponse?> FindManyPaginationAsync(FindManyPagesRequest request);
    Task<Page> FindOneAsync(Guid id);
    Task<Page?> CreateAsync(Page page);
    Task UpdateAsync(Guid id, UpdatePageParams @params);
    Task DeleteAsync(Guid id);
}