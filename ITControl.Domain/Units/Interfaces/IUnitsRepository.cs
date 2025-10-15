using ITControl.Domain.Shared.Params;
using ITControl.Domain.Units.Entities;
using ITControl.Domain.Units.Params;

namespace ITControl.Domain.Units.Interfaces;

public interface IUnitsRepository
{
    Task<Unit?> FindOneAsync(FindOneUnitsRepositoryParams @params);
    Task<IEnumerable<Unit>> FindManyAsync(
        FindManyUnitsRepositoryParams findManyParams,
        OrderByUnitsRepositoryParams? orderByParams = null,
        PaginationParams? paginationParams = null);
    Task CreateAsync(Unit unit);
    void Update(Unit unit);
    void Delete(Unit unit);
    Task<int> CountAsync(CountUnitsRepositoryParams @params);
    Task<bool> ExistsAsync(ExistsUnitsRepositoryParams @params);
    Task<bool> ExclusiveAsync(ExclusiveUnitsRepositoryParams @params);
}