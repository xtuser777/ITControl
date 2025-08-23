using ITControl.Domain.Entities;

namespace ITControl.Domain.Interfaces;

public interface IDepartmentsRepository
{
    Task<Department?> FindOneAsync(
        Guid id, bool? includeUser = null);
    Task<IEnumerable<Department>> FindManyAsync(
        string? alias = null, 
        string? name = null, 
        Guid? userId = null, 
        string? orderByAlias = null,
        string? orderByName = null,
        string? orderByUser = null,
        int? page = null, 
        int? size = null);
    Task CreateAsync(Department department);
    void Update(Department department);
    void Delete(Department department);
    Task<int> CountAsync(
        Guid? id = null,
        string? alias = null, 
        string? name = null, 
        Guid? userId = null);
    Task<bool> ExistsAsync(
        Guid? id = null,
        string? alias = null, 
        string? name = null, 
        Guid? userId = null);
    Task<bool> ExclusiveAsync(
        Guid id,
        string? alias = null, 
        string? name = null, 
        Guid? userId = null);
}