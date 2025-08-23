using ITControl.Domain.Entities;

namespace ITControl.Domain.Interfaces;

public interface ILocationsRepository
{
    Task<Location?> FindOneAsync(
        Guid id,
        bool? includeUnit = null,
        bool? includeUser = null,
        bool? includeDepartment = null,
        bool? includeDivision = null);
    Task<IEnumerable<Location>> FindManyAsync(
        string? description = null,
        Guid? unitId = null,
        Guid? userId = null,
        Guid? departmentId = null,
        Guid? divisionId = null,
        string? orderByDescription = null,
        string? orderByUnit = null,
        string? orderByUser = null,
        string? orderByDepartment = null,
        string? orderByDivision = null,
        int? page = null,
        int? size = null);
    Task CreateAsync(Location location);
    void Update(Location location);
    void Delete(Location location);
    Task<int> CountAsync(
        Guid? id = null,
        string? description = null,
        Guid? unitId = null,
        Guid? userId = null,
        Guid? departmentId = null,
        Guid? divisionId = null);
    Task<bool> ExistsAsync(
        Guid? id = null,
        string? description = null,
        Guid? unitId = null,
        Guid? userId = null,
        Guid? departmentId = null,
        Guid? divisionId = null);
    Task<bool> ExclusiveAsync(
        Guid id,
        string? description = null,
        Guid? unitId = null,
        Guid? userId = null,
        Guid? departmentId = null,
        Guid? divisionId = null);
}