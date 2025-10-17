using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Shared;

public interface IRepository
{
    Task<Entity?> FindOneAsync(IFindOneRepositoryParams @params);
    Task<IEnumerable<Entity>> FindManyAsync(
        IFindManyRepositoryParams findManyParams,
        IOrderByRepositoryParams orderByParams,
        PaginationParams paginationParams);
    Task CreateAsync(Entity entity);
    public void Update(Entity entity) { }
    public void Delete(Entity entity) { }
    Task<int> CountAsync(ICountRepositoryParams @params);
    public Task<bool> ExistsAsync(IExistsRepositoryParams @params)
    {
        return Task.FromResult(true);
    }
    public Task<bool> ExclusiveAsync(IExclusiveRepositoryParams @params)
    {
        return Task.FromResult(true);
    }
}
