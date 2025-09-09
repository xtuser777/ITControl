using ITControl.Domain.SupplementsMovements.Entities;

namespace ITControl.Domain.SupplementsMovements.Interfaces;

public interface ISupplementsMovementsRepository
{
    Task<SupplementMovement?> FindOneAsync(
        Guid id, bool? includeSupplement = null, bool? includeUser = null, bool? includeUnit = null, 
        bool? includeDepartment = null, bool? includeDivision = null);
    Task<IEnumerable<SupplementMovement>> FindManyAsync(
        int? quantity = null,
        DateOnly? movementDate = null,
        string? observation = null,
        Guid? supplementId = null,
        Guid? userId = null,
        Guid? unitId = null,
        Guid? departmentId = null,
        Guid? divisionId = null,
        string? orderByQuantity = null,
        string? orderByMovementDate = null,
        string? orderByObservation = null,
        string? orderBySupplement = null,
        string? orderByUser = null,
        string? orderByUnit = null,
        string? orderByDepartment = null,
        string? orderByDivision = null,
        int? page = null,
        int? size = null);
    Task CreateAsync(SupplementMovement supplementMovement);
    void Update(SupplementMovement supplementMovement);
    void Delete(SupplementMovement supplementMovement);
    Task<int> CountAsync(
        Guid? id = null,
        int? quantity = null,
        DateOnly? movementDate = null,
        string? observation = null,
        Guid? supplementId = null,
        Guid? userId = null,
        Guid? unitId = null,
        Guid? departmentId = null,
        Guid? divisionId = null);
    Task<bool> ExistsAsync(
        Guid? id = null,
        int? quantity = null,
        DateOnly? movementDate = null,
        string? observation = null,
        Guid? supplementId = null,
        Guid? userId = null,
        Guid? unitId = null,
        Guid? departmentId = null,
        Guid? divisionId = null);
}
