using ITControl.Application.Pages.Params;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Pages.Entities;

namespace ITControl.Application.Pages.Interfaces;

public interface IPagesService
{
    Task<Page> FindOneAsync(FindOnePagesServiceParams @params);
    Task<IEnumerable<Page>> FindManyAsync(
        FindManyPagesServiceParams @params);
    Task<PaginationResponse?> FindManyPaginationAsync(
        FindManyPaginationPagesServiceParams @params);
    Task<Page?> CreateAsync(CreatePagesServiceParams @params);
    Task UpdateAsync(UpdatePagesServiceParams @params);
    Task DeleteAsync(DeletePagesServiceParams @params);
}