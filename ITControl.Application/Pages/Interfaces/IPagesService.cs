using ITControl.Communication.Pages.Requests;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Pages.Entities;

namespace ITControl.Application.Pages.Interfaces;

public interface IPagesService
{
    Task<Page> FindOneAsync(FindOnePagesRequest request);
    Task<IEnumerable<Page>> FindManyAsync(
        FindManyPagesRequest findManyRequest,
        OrderByPagesRequest orderByRequest);
    Task<PaginationResponse?> FindManyPaginationAsync(FindManyPagesRequest request);
    Task<Page?> CreateAsync(CreatePagesRequest request);
    Task UpdateAsync(Guid id, UpdatePagesRequest request);
    Task DeleteAsync(Guid id);
}