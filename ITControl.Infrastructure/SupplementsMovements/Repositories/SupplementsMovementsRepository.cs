using ITControl.Domain.SupplementsMovements.Entities;
using ITControl.Domain.SupplementsMovements.Interfaces;
using ITControl.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.SupplementsMovements.Repositories;

public class SupplementsMovementsRepository(
    ApplicationDbContext context) : ISupplementsMovementsRepository
{
    public async Task<SupplementMovement?> FindOneAsync(
        Guid id, bool? includeSupplement = null, bool? includeUser = null, 
        bool? includeUnit = null, bool? includeDepartment = null, bool? includeDivision = null)
    {
        var query = context.SupplementsMovements.AsQueryable();
        if (includeSupplement == true)
            query = query.Include(sm => sm.Supplement);
        if (includeUser == true)
            query = query.Include(sm => sm.User);
        if (includeUnit == true)
            query = query.Include(sm => sm.Unit);
        if (includeDepartment == true)
            query = query.Include(sm => sm.Department);
        if (includeDivision == true)
            query = query.Include(sm => sm.Division);

        return await query.FirstOrDefaultAsync(sm => sm.Id == id);
    }

    public async Task<IEnumerable<SupplementMovement>> FindManyAsync(
        int? quantity = null, DateOnly? movementDate = null, string? observation = null, 
        Guid? supplementId = null, Guid? userId = null, Guid? unitId = null, 
        Guid? departmentId = null, Guid? divisionId = null, string? orderByQuantity = null, 
        string? orderByMovementDate = null, string? orderByObservation = null, string? orderBySupplement = null, 
        string? orderByUser = null, string? orderByUnit = null, string? orderByDepartment = null, string? orderByDivision = null, 
        int? page = null, int? size = null)
    {
        var query = context.SupplementsMovements
            .Include(sm => sm.Supplement)
            .Include(sm => sm.User)
            .Include(sm => sm.Unit)
            .Include(sm => sm.Department)
            .Include(sm => sm.Division)
            .AsNoTracking();
        query = ApplyFilters(query, null, quantity, movementDate, observation, 
            supplementId, userId, unitId, departmentId, divisionId);
        query = ApplyOrdering(query, orderByQuantity, orderByMovementDate, orderByObservation, 
            orderBySupplement, orderByUser, orderByUnit, orderByDepartment, orderByDivision);
        if (page.HasValue && size.HasValue)
        {
            int skip = (page.Value - 1) * size.Value;
            query = query.Skip(skip).Take(size.Value);
        }

        return await query.ToListAsync();
    }

    public async Task CreateAsync(SupplementMovement supplementMovement)
    {
        await context.SupplementsMovements.AddAsync(supplementMovement);
    }

    public void Update(SupplementMovement supplementMovement)
    {
        context.SupplementsMovements.Update(supplementMovement);
    }

    public void Delete(SupplementMovement supplementMovement)
    {
        context.SupplementsMovements.Remove(supplementMovement);
    }

    public async Task<int> CountAsync(
        Guid? id = null, int? quantity = null, DateOnly? movementDate = null, 
        string? observation = null, Guid? supplementId = null, Guid? userId = null, 
        Guid? unitId = null, Guid? departmentId = null, Guid? divisionId = null)
    {
        var query = context.SupplementsMovements.AsNoTracking();
        query = ApplyFilters(query, id, quantity, movementDate, observation, 
            supplementId, userId, unitId, departmentId, divisionId);

        return await query.CountAsync();
    }

    public async Task<bool> ExistsAsync(
        Guid? id = null, int? quantity = null, DateOnly? movementDate = null, 
        string? observation = null, Guid? supplementId = null, Guid? userId = null, 
        Guid? unitId = null, Guid? departmentId = null, Guid? divisionId = null)
    {
        var count = await CountAsync(id, quantity, movementDate, observation, 
            supplementId, userId, unitId, departmentId, divisionId);

        return count > 0;
    }

    private IQueryable<SupplementMovement> ApplyFilters(
        IQueryable<SupplementMovement> query,
        Guid? id = null,
        int? quantity = null,
        DateOnly? movementDate = null,
        string? observation = null,
        Guid? supplementId = null,
        Guid? userId = null,
        Guid? unitId = null,
        Guid? departmentId = null,
        Guid? divisionId = null)
    {
        if (id.HasValue)
            query = query.Where(sm => sm.Id == id.Value);
        if (quantity.HasValue)
            query = query.Where(sm => sm.Quantity == quantity.Value);
        if (movementDate.HasValue)
            query = query.Where(sm => sm.MovementDate == movementDate.Value);
        if (!string.IsNullOrEmpty(observation))
            query = query.Where(sm => sm.Observation.Contains(observation));
        if (supplementId.HasValue)
            query = query.Where(sm => sm.SupplementId == supplementId.Value);
        if (userId.HasValue)
            query = query.Where(sm => sm.UserId == userId.Value);
        if (unitId.HasValue)
            query = query.Where(sm => sm.UnitId == unitId.Value);
        if (departmentId.HasValue)
            query = query.Where(sm => sm.DepartmentId == departmentId.Value);
        if (divisionId.HasValue)
            query = query.Where(sm => sm.DivisionId == divisionId.Value);
        return query;
    }

    private IQueryable<SupplementMovement> ApplyOrdering(
        IQueryable<SupplementMovement> query,
        string? orderByQuantity,
        string? orderByMovementDate,
        string? orderByObservation,
        string? orderBySupplement,
        string? orderByUser,
        string? orderByUnit,
        string? orderByDepartment,
        string? orderByDivision)
    {
        if (!string.IsNullOrEmpty(orderByQuantity))
        {
            query = orderByQuantity.ToLower() switch
            {
                "a" => query.OrderBy(sm => sm.Quantity),
                "d" => query.OrderByDescending(sm => sm.Quantity),
                _ => query
            };
        }
        if (!string.IsNullOrEmpty(orderByMovementDate))
        {
            query = orderByMovementDate.ToLower() switch
            {
                "a" => query.OrderBy(sm => sm.MovementDate),
                "d" => query.OrderByDescending(sm => sm.MovementDate),
                _ => query
            };
        }
        if (!string.IsNullOrEmpty(orderByObservation))
        {
            query = orderByObservation.ToLower() switch
            {
                "a" => query.OrderBy(sm => sm.Observation),
                "d" => query.OrderByDescending(sm => sm.Observation),
                _ => query
            };
        }
        if (!string.IsNullOrEmpty(orderBySupplement))
        {
            query = orderBySupplement.ToLower() switch
            {
                "a" => query.OrderBy(sm => sm.Supplement!.Brand),
                "d" => query.OrderByDescending(sm => sm.Supplement!.Brand),
                _ => query
            };
        }
        if (!string.IsNullOrEmpty(orderByUser))
        {
            query = orderByUser.ToLower() switch
            {
                "a" => query.OrderBy(sm => sm.User!.Username),
                "d" => query.OrderByDescending(sm => sm.User!.Username),
                _ => query
            };
        }
        if (!string.IsNullOrEmpty(orderByUnit))
        {
            query = orderByUnit.ToLower() switch
            {
                "a" => query.OrderBy(sm => sm.Unit!.Name),
                "d" => query.OrderByDescending(sm => sm.Unit!.Name),
                _ => query
            };
        }
        if (!string.IsNullOrEmpty(orderByDepartment))
        {
            query = orderByDepartment.ToLower() switch
               {
                "a" => query.OrderBy(sm => sm.Department!.Name),
                "d" => query.OrderByDescending(sm => sm.Department!.Name),
                _ => query
            };
        }
        if (!string.IsNullOrEmpty(orderByDivision))
        {
            query = orderByDivision.ToLower() switch
            {
                "a" => query.OrderBy(sm => sm.Division!.Name),
                "d" => query.OrderByDescending(sm => sm.Division!.Name),
                _ => query
            };
        }
        return query;
    }
}
