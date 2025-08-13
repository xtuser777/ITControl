using ITControl.Domain.Entities;

namespace ITControl.Domain.Interfaces;

public interface IDivisionsRepository
{
    Task<Division?> FindOneAsync(
        Guid id, 
        bool? includeDepartment = null, 
        bool? includeUser = null);
    Task<IEnumerable<Division>> FindManyAsync(
        string? name = null,
        Guid? departmentId = null,
        Guid? userId = null,
        string? orderByName = null,
        string? orderByDepartment = null,
        string? orderByUser = null,
        int? page = null,
        int? size = null);
    Task CreateAsync(Division division);
    Task UpdateAsync(Division division);
    Task DeleteAsync(Division division);
    Task<int> CountAsync(
        Guid? id = null,
        string? name = null,
        Guid? departmentId = null,
        Guid? userId = null);
    Task<bool> ExistsAsync(
        Guid? id = null,
        string? name = null,
        Guid? departmentId = null,
        Guid? userId = null);
    Task<bool> Exclusive(Guid id, string? name = null);
}