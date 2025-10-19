using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Shared;

public interface IRepository
{
    Task<Entity?> FindOneAsync(IFindOneRepositoryParams @params);

    public Task<Entity?> FindOneAsync(Guid id)
    {
        return Task.FromResult<Entity?>(null);
    }
    Task<IEnumerable<Entity>> FindManyAsync(
        IFindManyRepositoryParams findManyParams,
        IOrderByRepositoryParams? orderByParams = null,
        PaginationParams? paginationParams = null);
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
