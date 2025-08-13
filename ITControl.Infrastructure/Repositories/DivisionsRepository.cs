using ITControl.Domain.Entities;
using ITControl.Domain.Interfaces;
using ITControl.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Repositories;

public class DivisionsRepository(ApplicationDbContext context) : IDivisionsRepository
{
    public async Task<Division?> FindOneAsync(
        Guid id, 
        bool? includeDepartment = null, 
        bool? includeUser = null)
    {
        var query = context.Divisions.AsQueryable();
        if (includeDepartment is not null) 
            query = query.Include(x => x.Department);
        if (includeUser is not null) 
            query = query.Include(x => x.User);
        
        return await query.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Division>> FindManyAsync(
        string? name = null, 
        Guid? departmentId = null, 
        Guid? userId = null, 
        string? orderByName = null,
        string? orderByDepartment = null, 
        string? orderByUser = null, 
        int? page = null, 
        int? size = null)
    {
        var query = context.Divisions.AsNoTracking();
        query = BuildQuery(query, null, name, departmentId, userId);
        query = BuildOrderBy(query, orderByName, orderByDepartment, orderByUser);
        if (page != null && size != null) query = query.Skip((page.Value - 1) * size.Value).Take(size.Value);
        
        return await query.ToListAsync();
    }

    public async Task CreateAsync(Division division)
    {
        await context.Divisions.AddAsync(division);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Division division)
    {
        context.Divisions.Update(division);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Division division)
    {
        context.Divisions.Remove(division);
        await context.SaveChangesAsync();
    }

    public async Task<int> CountAsync(
        Guid? id = null, 
        string? name = null, 
        Guid? departmentId = null, 
        Guid? userId = null)
    {
        var query = context.Divisions.AsNoTracking();
        query = BuildQuery(query, id, name, departmentId, userId);
        
        return await query.CountAsync();
    }

    public async Task<bool> ExistsAsync(
        Guid? id = null, 
        string? name = null, 
        Guid? departmentId = null, 
        Guid? userId = null)
    {
        var count = await CountAsync(id, name, departmentId, userId);
        
        return count > 0;
    }

    public async Task<bool> Exclusive(Guid id, string? name = null)
    {
        var query = context.Divisions.AsNoTracking();
        query = query.Where(x => x.Id != id);
        query = BuildQuery(query, null, name, null, null);
        var count = await query.CountAsync();
        
        return count > 0;
    }

    private IQueryable<Division> BuildQuery(
        IQueryable<Division> query, 
        Guid? id = null, 
        string? name = null, 
        Guid? departmentId = null, 
        Guid? userId = null)
    {
        if (id is not null) 
            query = query.Where(x => x.Id == id);
        if (name is not null) 
            query = query.Where(x => x.Name.Contains(name));
        if (departmentId is not null) 
            query = query.Where(x => x.DepartmentId == departmentId);
        if (userId is not null) 
            query = query.Where(x => x.UserId == userId);
        
        return query;
    }

    private IQueryable<Division> BuildOrderBy(
        IQueryable<Division> query,
        string? orderByName = null,
        string? orderByDepartment = null,
        string? orderByUser = null)
    {
        if (orderByName is not null) 
            query = query.OrderBy(x => x.Name);
        if (orderByDepartment is not null) 
            query = query.Include(x => x.Department)
                .OrderBy(x => x.Department!.Name);
        if (orderByUser is not null) 
            query = query.Include(x => x.User)
                .OrderBy(x => x.User!.Name);
        
        return query;
    }
}