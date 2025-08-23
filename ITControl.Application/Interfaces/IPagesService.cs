using ITControl.Communication.Pages.Requests;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Entities;

namespace ITControl.Application.Interfaces;

public interface IPagesService
{
    Task<IEnumerable<Page>> FindManyAsync(FindManyPagesRequest request);
    Task<PaginationResponse?> FindManyPaginationAsync(FindManyPagesRequest request);
    Task<Page> FindOneAsync(Guid id);
    Task<Page?> CreateAsync(CreatePagesRequest request);
    Task UpdateAsync(Guid id, UpdatePagesRequest request);
    Task DeleteAsync(Guid id);
}