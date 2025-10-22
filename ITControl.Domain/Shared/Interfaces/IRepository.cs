using ITControl.Domain.Shared.Params2;

namespace ITControl.Domain.Shared.Interfaces;

public interface IRepository<T>
{
    Task<T?> FindOneAsync(FindOneRepositoryParams @params);
    Task<IEnumerable<T>> FindManyAsync(
        FindManyRepositoryParams @params);
    Task CreateAsync(T entity);
    public void Update(T entity) { }
    public void Delete(T entity) { }
    Task<int> CountAsync(FindManyParams @params);
    public Task<bool> ExistsAsync(FindManyParams @params)
    {
        return Task.FromResult(true);
    }
    public Task<bool> ExclusiveAsync(FindManyParams @params)
    {
        return Task.FromResult(true);
    }
}
