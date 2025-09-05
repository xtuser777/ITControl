using ITControl.Domain.Departments.Entities;
using ITControl.Domain.Departments.Interfaces;
using ITControl.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Departments.Repositories;

public class DepartmentsRepository(ApplicationDbContext context) : IDepartmentsRepository
{
    public async Task<Department?> FindOneAsync(
        Guid id, bool? includeUser = null)
    {
        var query = context.Departments.AsQueryable();
        if (includeUser != null) query = query.Include(x => x.User);
        
        return await query.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Department>> FindManyAsync(
        string? alias = null, 
        string? name = null, 
        Guid? userId = null, 
        string? orderByAlias = null,
        string? orderByName = null,
        string? orderByUser = null,
        int? page = null, 
        int? size = null)
    {
        var query = context.Departments.AsNoTracking();
        query = BuildQuery(
            query: query,
            alias: alias,
            name: name,
            userId: userId);
        query = BuildOrderBy(
            query: query,
            orderByAlias: orderByAlias,
            orderByName: orderByName,
            orderByUser: orderByUser);
        if (page != null && size != null) query = query.Skip((page.Value - 1) * size.Value).Take(size.Value);
        
        return await query.ToListAsync();
    }

    public async Task CreateAsync(Department department)
    {
        await context.Departments.AddAsync(department);
    }

    public void Update(Department department)
    {
        context.Departments.Update(department);
    }

    public void Delete(Department department)
    {
        context.Departments.Remove(department);
    }

    public async Task<int> CountAsync(
        Guid? id = null, 
        string? alias = null, 
        string? name = null, 
        Guid? userId = null)
    {
        var query = context.Departments.AsNoTracking();
        query = BuildQuery(
            query: query,
            id: id,
            alias: alias,
            name: name,
            userId: userId);
        
        return await query.CountAsync();
    }

    public async Task<bool> ExistsAsync(
        Guid? id = null, 
        string? alias = null, 
        string? name = null, 
        Guid? userId = null)
    {
        var count = await CountAsync(id, alias, name, userId);
        
        return count > 0;
    }

    public async Task<bool> ExclusiveAsync(
        Guid id, 
        string? alias = null, 
        string? name = null, 
        Guid? userId = null)
    {
        var query = context.Departments.AsNoTracking();
        query = query.Where(x => x.Id != id);
        query = BuildQuery(
            query: query,
            alias: alias,
            name: name,
            userId: userId);
        var count = await query.CountAsync();
        
        return count > 0;
    }

    private IQueryable<Department> BuildQuery(
        IQueryable<Department> query, 
        Guid? id = null, 
        string? alias = null, 
        string? name = null, 
        Guid? userId = null)
    {
        if (id is not null) query = query.Where(x => x.Id == id);
        if (alias is not null) query = query.Where(x => x.Alias.Contains(alias));
        if (name is not null) query = query.Where(x => x.Name.Contains(name));
        if (userId is not null) query = query.Where(x => x.UserId == userId);
        
        return query;
    }

    private IQueryable<Department> BuildOrderBy(
        IQueryable<Department> query,
        string? orderByAlias = null,
        string? orderByName = null,
        string? orderByUser = null)
    {
        query = orderByAlias switch
        {
            "a" => query.OrderBy(p => p.Alias),
            "d" => query.OrderByDescending(p => p.Alias),
            _ => query
        };
        query = orderByName switch
        {
            "a" => query.OrderBy(p => p.Name),
            "d" => query.OrderByDescending(p => p.Name),
            _ => query
        };
        query = orderByUser switch
        {
            "a" => query.Include(x => x.User).OrderBy(p => p.User!.Name),
            "d" => query.Include(x => x.User).OrderByDescending(p => p.User!.Name),
            _ => query
        };
        
        return query;
    }
}