using ITControl.Domain.Entities;
using ITControl.Domain.Interfaces;
using ITControl.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ITControl.Infrastructure.Repositories;

public class LocationsRepository(ApplicationDbContext context) : ILocationsRepository
{
    public async Task<Location?> FindOneAsync(
        Expression<Func<Location?, bool>> predicate,
        bool? includeUnit = null,
        bool? includeUser = null,
        bool? includeDepartment = null,
        bool? includeDivision = null)
    {
        var query = context.Locations.AsQueryable();
        if (includeUnit != null) query = query.Include(x => x.Unit);
        if (includeUser != null) query = query.Include(x => x.User);
        if (includeDepartment != null) query = query.Include(x => x.Department);
        if (includeDivision != null) query = query.Include(x => x.Division);
        
        return await query.FirstOrDefaultAsync(predicate);
    }

    public async Task<IEnumerable<Location>> FindManyAsync(
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
        int? page = null, int? size = null)
    {
        var query = context.Locations.AsNoTracking();
        query = BuildQuery(
            query: query,
            description: description,
            unitId: unitId,
            userId: userId,
            departmentId: departmentId,
            divisionId: divisionId);
        query = BuildOrderBy(
            query: query,
            orderByDescription: orderByDescription,
            orderByUnit: orderByUnit,
            orderByUser: orderByUser,
            orderByDepartment: orderByDepartment,
            orderByDivision: orderByDivision);
        if (page != null && size != null) query = query.Skip((page.Value - 1) * size.Value).Take(size.Value);
        
        return await query.ToListAsync();
    }

    public async Task CreateAsync(Location location)
    {
        await context.Locations.AddAsync(location);
    }

    public void Update(Location location)
    {
        context.Locations.Update(location);
    }

    public void Delete(Location location)
    {
        context.Locations.Remove(location);
    }

    public async Task<int> CountAsync(
        Guid? id = null, 
        string? description = null, 
        Guid? unitId = null, 
        Guid? userId = null,
        Guid? departmentId = null, 
        Guid? divisionId = null)
    {
        var query = context.Locations.AsNoTracking();
        query = BuildQuery(
            query: query,
            id: id,
            description: description,
            unitId: unitId,
            userId: userId,
            departmentId: departmentId,
            divisionId: divisionId);
        
        return await query.CountAsync();
    }

    public async Task<bool> ExistsAsync(
        Guid? id = null, 
        string? description = null, 
        Guid? unitId = null, 
        Guid? userId = null,
        Guid? departmentId = null, 
        Guid? divisionId = null)
    {
        var count = await CountAsync(
            id,
            description,
            unitId,
            userId,
            departmentId,
            divisionId);
        
        return count > 0;
    }

    public async Task<bool> ExclusiveAsync(
        Guid id, 
        string? description = null, 
        Guid? unitId = null, 
        Guid? userId = null,
        Guid? departmentId = null, 
        Guid? divisionId = null)
    {
        var query = context.Locations.AsNoTracking();
        query = query.Where(x => x.Id != id);
        query = BuildQuery(
            query: query,
            id: id,
            description: description,
            unitId: unitId,
            userId: userId,
            departmentId: departmentId,
            divisionId: divisionId);
        var count = await query.CountAsync();
        
        return count > 0;
    }

    private IQueryable<Location> BuildQuery(
        IQueryable<Location> query,
        Guid? id = null, 
        string? description = null, 
        Guid? unitId = null, 
        Guid? userId = null,
        Guid? departmentId = null, 
        Guid? divisionId = null)
    {
        if (id != null) query = query.Where(x => x.Id == id);
        if (description != null) query = query.Where(x => x.Description.Contains(description));
        if (unitId != null) query = query.Where(x => x.UnitId == unitId);
        if (userId != null) query = query.Where(x => x.UserId == userId);
        if (departmentId != null) query = query.Where(x => x.DepartmentId == departmentId);
        if (divisionId != null) query = query.Where(x => x.DivisionId == divisionId);
        
        return query;
    }

    private IQueryable<Location> BuildOrderBy(
        IQueryable<Location> query,
        string? orderByDescription = null, 
        string? orderByUnit = null,
        string? orderByUser = null, 
        string? orderByDepartment = null, 
        string? orderByDivision = null)
    {
        query = orderByDescription switch
        {
            "a" => query.OrderBy(p => p.Description),
            "d" => query.OrderByDescending(p => p.Description),
            _ => query
        };
        query = orderByUnit switch
        {
            "a" => query.Include(x => x.Unit).OrderBy(p => p.Unit!.Name),
            "d" => query.Include(x => x.Unit).OrderByDescending(p => p.Unit!.Name),
            _ => query
        };
        query = orderByUser switch
        {
            "a" => query.Include(x => x.User).OrderBy(p => p.User!.Name),
            "d" => query.Include(x => x.User).OrderByDescending(p => p.User!.Name),
            _ => query
        };
        query = orderByDepartment switch
        {
            "a" => query.Include(x => x.Department).OrderBy(p => p.Department!.Alias),
            "d" => query.Include(x => x.Department).OrderByDescending(p => p.Department!.Alias),
            _ => query
        };
        query = orderByDivision switch
        {
            "a" => query.Include(x=>x.Division).OrderBy(p => p.Division!.Name),
            "d" => query.Include(x=>x.Division).OrderByDescending(p => p.Division!.Name),
            _ => query
        };
        
        return query;
    }
}