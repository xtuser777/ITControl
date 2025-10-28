using ITControl.Application.Shared.Params;
using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Supplements.Entities;

namespace ITControl.Application.Supplements.Interfaces;

public interface ISupplementsService
{
    Task<Supplement> FindOneAsync(
        FindOneServiceParams parameters);
    Task<IEnumerable<Supplement>> FindManyAsync(
        FindManyServiceParams parameters);
    Task<PaginationModel?> FindManyPagination(
        FindManyPaginationServiceParams parameters);
    Task<Supplement?> CreateAsync(
        CreateServiceParams parameters);
    Task UpdateAsync(
        UpdateServiceParams parameters);
    Task DeleteAsync(
        DeleteServiceParams parameters);
}
