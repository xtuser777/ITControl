using ITControl.Domain.Shared.Params;
using ITControl.Domain.Systems.Params;

namespace ITControl.Domain.Systems.Interfaces;

public interface ISystemsRepository
{
    Task<Entities.System?> FindOneAsync(FindOneSystemsRepositoryParams @params);
    Task<IEnumerable<Entities.System>> FindManyAsync(
        FindManySystemsRepositoryParams findManyParams,
        OrderBySystemsRepositoryParams orderByParams,
        PaginationParams paginationParams);
    Task CreateAsync(Entities.System system);
    void Update(Entities.System system);
    void Delete(Entities.System system);
    Task<int> CountAsync(CountSystemsRepositoryParams @params);
    Task<bool> ExistsAsync(ExistsSystemsRepositoryParams @params);
}