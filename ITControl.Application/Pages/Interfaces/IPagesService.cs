using ITControl.Application.Shared.Params;
using ITControl.Domain.Pages.Entities;
using ITControl.Domain.Shared.Entities;

namespace ITControl.Application.Pages.Interfaces;

public interface IPagesService
{
    Task<Page> FindOneAsync(
        FindOneServiceParams parameters);
    Task<IEnumerable<Page>> FindManyAsync(
        FindManyServiceParams parameters);
    Task<PaginationModel?> FindManyPaginationAsync(
        FindManyPaginationServiceParams parameters);
    Task<Page?> CreateAsync(
        CreateServiceParams parameters);
    Task UpdateAsync(
        UpdateServiceParams parameters);
    Task DeleteAsync(
        DeleteServiceParams parameters);
}