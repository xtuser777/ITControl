using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Shared.Interfaces;

public interface IRepository<T>
{
    Task<T?> FindOneAsync(FindOneRepositoryParams @params);
    Task<IEnumerable<T>> FindManyAsync(
        FindManyRepositoryParams @params);
    Task CreateAsync(T entity);
    public void Update(T entity) { }
    public void Delete(T entity) { }
    public void SoftDelete(T entity) { }
    Task<int> CountAsync(FindManyParams @params)
    {
        return Task.FromResult(0);
    }
    Task<int> CountAsync(Entity props)
    {
        return Task.FromResult(0);
    }
    public Task<bool> ExistsAsync(Entity props)
    {
        return Task.FromResult(true);
    }
    public Task<bool> ExistsAsync(FindManyParams @params)
    {
        return Task.FromResult(true);
    }
    public Task<bool> ExclusiveAsync(FindManyParams @params)
    {
        return Task.FromResult(true);
    }
    public Task<bool> ExclusiveAsync(Entity props)
    {
        return Task.FromResult(true);
    }
}
