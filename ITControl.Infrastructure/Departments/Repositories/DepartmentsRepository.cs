using ITControl.Domain.Departments.Entities;
using ITControl.Domain.Departments.Interfaces;
using ITControl.Domain.Departments.Params;
using ITControl.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Departments.Repositories;

public class DepartmentsRepository(ApplicationDbContext context) : IDepartmentsRepository
{
    public async Task<Department?> FindOneAsync(
        FindOneDepartmentsRepositoryParams @params)
    {
        return await context.Departments.FindAsync(@params.Id);
    }

    public async Task<IEnumerable<Department>> FindManyAsync(
        FindManyDepartmentsRepositoryParams @params)
    {
        var query = context.Departments.AsNoTracking();
        var (alias, name, orderByAlias, orderByName, page, size) = @params;
        query = BuildQuery(new ()
        {
            Query = query,
            Alias = alias,
            Name = name
        });
        query = BuildOrderBy(new ()
        {
            Query = query,
            OrderByAlias = orderByAlias,
            OrderByName = orderByName
        });
        if (page != null && size != null) 
            query = query.Skip((page.Value - 1) * size.Value).Take(size.Value);
        
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

    public async Task<int> CountAsync(CountDepartmentsRepositoryParams @params)
    {
        var query = context.Departments.AsNoTracking();
        var (id, alias, name) = @params;
        query = BuildQuery(new ()
        {
            Query = query,
            Id = id,
            Alias = alias,
            Name = name,
        });
        
        return await query.CountAsync();
    }

    public async Task<bool> ExistsAsync(ExistsDepartmentsRepositoryParams @params)
    {
        var (id, alias, name) = @params;
        var count = await CountAsync(new ()
        {
            Id = id,
            Alias = alias,
            Name = name,
        });
        
        return count > 0;
    }

    public async Task<bool> ExclusiveAsync(ExclusiveDepartmentsRepositoryParams @params)
    {
        var query = context.Departments.AsNoTracking();
        var (id, alias, name) = @params;
        query = query.Where(x => x.Id != id);
        query = BuildQuery(new ()
        {
            Query = query,
            Alias = alias,
            Name = name,
        });
        var count = await query.CountAsync();
        
        return count > 0;
    }

    private static IQueryable<Department> BuildQuery(BuildQueryParams @params)
    {
        var (query, id, alias, name) = @params;
        if (id is not null) query = query.Where(x => x.Id == id);
        if (alias is not null) query = query.Where(x => x.Alias.Contains(alias));
        if (name is not null) query = query.Where(x => x.Name.Contains(name));
        
        return query;
    }

    private static IQueryable<Department> BuildOrderBy(BuildOrderByParams @params)
    {
        var (query, orderByAlias, orderByName) = @params;
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
        
        return query;
    }
}

class BuildQueryParams
{
    public IQueryable<Department> Query { get; set; } = null!;
    public Guid? Id { get; set; }
    public string? Alias { get; set; }
    public string? Name { get; set; }

    internal void Deconstruct(out IQueryable<Department> query, out Guid? id, out string? alias, out string? name)
    {
        query = Query;
        id = Id;
        alias = Alias;
        name = Name;
    }
}

class BuildOrderByParams
{
    public IQueryable<Department> Query { get; set; } = null!;
    public string? OrderByAlias { get; set; }
    public string? OrderByName { get; set; }

    internal void Deconstruct(out IQueryable<Department> query, out string? orderByAlias, out string? orderByName)
    {
        query = Query;
        orderByAlias = OrderByAlias;
        orderByName = OrderByName;
    }
}