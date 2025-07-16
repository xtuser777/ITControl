using ITControl.Communication.Pages.Requests;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Entities;

namespace ITControl.Application.Interfaces;

public interface IPagesService
{
    Task<IEnumerable<Page>> FindMany(FindManyPagesRequest request);
    Task<PaginationResponse?> FindManyPagination(FindManyPagesRequest request);
    Task<Page?> FindOne(Guid id);
    Task<Page?> Create(CreatePagesRequest request);
    Task Update(Guid id, UpdatePagesRequest request);
    Task Delete(Guid id);
}