using ITControl.Domain.Divisions.Entities;
using ITControl.Domain.Divisions.Interfaces;
using ITControl.Domain.Divisions.Params;
using ITControl.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Divisions.Repositories;

public class DivisionsRepository(ApplicationDbContext context) : IDivisionsRepository
{
    public async Task<Division?> FindOneAsync(FindOneDivisionsRepositoryParams @params)
    {
        var (id, includeDepartment) = @params;
        var query = context.Divisions.AsQueryable();
        if (includeDepartment is not null) 
            query = query.Include(x => x.Department);
        
        return await query.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Division>> FindManyAsync(FindManyDivisionsRepositoryParams @params)
    {
        var (name, departmentId, orderByName, orderByDepartment, page, size) = @params;
        var query = context.Divisions.AsNoTracking();
        query = BuildQuery(new() { Query = query, Name = name, DepartmentId = departmentId });
        query = BuildOrderBy(new () { 
            Query = query, 
            OrderByName = orderByName, 
            OrderByDepartment = orderByDepartment
        });
        if (page != null && size != null) 
            query = query.Skip((page.Value - 1) * size.Value).Take(size.Value);
        
        return await query.ToListAsync();
    }

    public async Task CreateAsync(Division division)
    {
        await context.Divisions.AddAsync(division);
    }

    public void Update(Division division)
    {
        context.Divisions.Update(division);
    }

    public void Delete(Division division)
    {
        context.Divisions.Remove(division);
    }

    public async Task<int> CountAsync(CountDivisionsRepositoryParams @params)
    {
        var (id, name, departmentId) = @params;
        var query = context.Divisions.AsNoTracking();
        query = BuildQuery(new() { 
            Query = query, 
            Id = id, Name = name, 
            DepartmentId = departmentId 
        });
        
        return await query.CountAsync();
    }

    public async Task<bool> ExistsAsync(ExistsDivisionsRepositoryParams @params)
    {
        var count = await CountAsync(@params);
        
        return count > 0;
    }

    public async Task<bool> ExclusiveAsync(ExclusiveDivisionsRepositoryParams @params)
    {
        var (id, name) = @params;
        var query = context.Divisions.AsNoTracking();
        query = query.Where(x => x.Id != id);
        query = BuildQuery(new () { Query = query, Params = new() { Name = name } });
        var count = await query.CountAsync();
        
        return count > 0;
    }

    private static IQueryable<Division> BuildQuery(BuildQueryDivisionsRepositoryParams @queryParams)
    {
        var (query, @params) = @queryParams;
        if (@params.Id is not null) 
            query = query.Where(x => x.Id == @params.Id);
        if (@params.Name is not null) 
            query = query.Where(x => x.Name.Contains(@params.Name));
        if (@params.DepartmentId is not null) 
            query = query.Where(x => x.DepartmentId == @params.DepartmentId);
        
        return query;
    }

    private static IQueryable<Division> BuildOrderBy(BuildOrderByDivisionsRepositoryParams @orderByParams)
    {
        var (query, @params) = @orderByParams;
        query = @params.OrderByName switch
        {
            "a" => query.OrderBy(p => p.Name),
            "d" => query.OrderByDescending(p => p.Name),
            _ => query
        };
        query = @params.OrderByDepartment switch
        {
            "a" => query.Include(x => x.Department).OrderBy(p => p.Department!.Alias),
            "d" => query.Include(x => x.Department).OrderByDescending(p => p.Department!.Alias),
            _ => query
        };

        return query;
    }
}