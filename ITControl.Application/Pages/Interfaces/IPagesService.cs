using ITControl.Application.Shared.Params;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Pages.Entities;

namespace ITControl.Application.Pages.Interfaces;

public interface IPagesService
{
    Task<Page> FindOneAsync(
        FindOneServiceParams parameters);
    Task<IEnumerable<Page>> FindManyAsync(
        FindManyServiceParams parameters);
    Task<PaginationResponse?> FindManyPaginationAsync(
        FindManyPaginationServiceParams parameters);
    Task<Page?> CreateAsync(
        CreateServiceParams parameters);
    Task UpdateAsync(
        UpdateServiceParams parameters);
    Task DeleteAsync(
        DeleteServiceParams parameters);
}