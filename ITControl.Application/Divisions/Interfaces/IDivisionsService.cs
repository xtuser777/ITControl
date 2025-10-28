using ITControl.Application.Shared.Params;
using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Divisions.Entities;

namespace ITControl.Application.Divisions.Interfaces;

public interface IDivisionsService
{
    Task<Division> FindOneAsync(
        FindOneServiceParams parameters);
    Task<IEnumerable<Division>> FindManyAsync(
        FindManyServiceParams parameters);
    Task<PaginationModel?> FindManyPaginatedAsync(
        FindManyPaginationServiceParams parameters);
    Task<Division?> CreateAsync(
        CreateServiceParams parameters);
    Task UpdateAsync(
        UpdateServiceParams parameters);
    Task DeleteAsync(
        DeleteServiceParams parameters);
}