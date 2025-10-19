using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Shared;

public interface IRepository<T>
{
    Task<T?> FindOneAsync(FindOneRepositoryParams @params);

    public Task<T?> FindOneAsync(Guid id)
    {
        return Task.FromResult<T?>(default);
    }
    Task<IEnumerable<T>> FindManyAsync(
        FindManyRepositoryParams findManyParams,
        OrderByRepositoryParams? orderByParams = null,
        PaginationParams? paginationParams = null);
    Task CreateAsync(T entity);
    public void Update(T entity) { }
    public void Delete(T entity) { }
    Task<int> CountAsync(FindManyRepositoryParams @params);
    public Task<bool> ExistsAsync(FindManyRepositoryParams @params)
    {
        return Task.FromResult(true);
    }
    public Task<bool> ExclusiveAsync(FindManyRepositoryParams @params)
    {
        return Task.FromResult(true);
    }
}
