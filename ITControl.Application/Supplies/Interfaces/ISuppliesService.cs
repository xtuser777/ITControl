using ITControl.Application.Shared.Params;
using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Supplies.Entities;

namespace ITControl.Application.Supplies.Interfaces;

public interface ISuppliesService
{
    Task<Supply> FindOneAsync(
        FindOneServiceParams parameters);
    Task<IEnumerable<Supply>> FindManyAsync(
        FindManyServiceParams parameters);
    Task<PaginationModel?> FindManyPagination(
        FindManyPaginationServiceParams parameters);
    Task<Supply?> CreateAsync(
        CreateServiceParams parameters);
    Task UpdateAsync(
        UpdateServiceParams parameters);
    Task DeleteAsync(
        DeleteServiceParams parameters);
}
