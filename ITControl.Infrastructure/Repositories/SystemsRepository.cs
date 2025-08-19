using ITControl.Domain.Entities;
using ITControl.Domain.Interfaces;
using ITControl.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ITControl.Infrastructure.Repositories;

public class SystemsRepository(ApplicationDbContext context) : ISystemsRepository
{
    public async Task<Domain.Entities.System?> FindOneAsync(
        Expression<Func<Domain.Entities.System?, bool>> predicate, bool? includeContract = null)
    {
        var query = context.Systems.AsQueryable();
        if (includeContract != null) query = query.Include(x => x.Contract);
        
        return await query.FirstOrDefaultAsync(predicate);
    }

    public async Task<IEnumerable<Domain.Entities.System>> FindManyAsync(
        string? name = null, 
        string? version = null, 
        DateOnly? implementedAt = null,
        DateOnly? endedAt = null, 
        bool? own = null, 
        string? orderByName = null,
        string? orderByVersion = null, 
        string? orderByImplementedAt = null, 
        string? orderByEndedAt = null,
        string? orderByOwn = null,
        int? page = null, int? size = null)
    {
        var query = context.Systems.AsNoTracking();
        query = BuildQuery(
            query: query,
            name: name,
            version: version,
            implementedAt: implementedAt,
            endedAt: endedAt,
            own: own);
        query = BuildOrderBy(
            query, 
            orderByName, 
            orderByVersion, 
            orderByImplementedAt, 
            orderByEndedAt, 
            orderByOwn);
        if (page != null && size != null) query = query.Skip((page.Value - 1) * size.Value).Take(size.Value);
        
        return await query.ToListAsync();
    }

    public async Task CreateAsync(Domain.Entities.System system)
    {
        await context.Systems.AddAsync(system);
    }

    public void Update(Domain.Entities.System system)
    {
        context.Systems.Update(system);
    }

    public void Delete(Domain.Entities.System system)
    {
        context.Systems.Remove(system);
    }

    public async Task<int> CountAsync(
        Guid? id = null, 
        string? name = null, 
        string? version = null, 
        DateOnly? implementedAt = null,
        DateOnly? endedAt = null, 
        bool? own = null)
    {
        var query = context.Systems.AsNoTracking();
        query = BuildQuery(
            id: id,
            query: query,
            name: name,
            version: version,
            implementedAt: implementedAt,
            endedAt: endedAt,
            own: own);
        
        return await query.CountAsync();
    }

    public async Task<bool> ExistsAsync(
        Guid? id = null, 
        string? name = null, 
        string? version = null, 
        DateOnly? implementedAt = null,
        DateOnly? endedAt = null, 
        bool? own = null)
    {
        var count = await CountAsync(id, name, version, implementedAt, endedAt, own);
        
        return count > 0;
    }

    public async Task<bool> ExclusiveAsync(
        Guid id, 
        string? name = null, 
        string? version = null, 
        DateOnly? implementedAt = null,
        DateOnly? endedAt = null, 
        bool? own = null)
    {
        var query = context.Systems.AsNoTracking();
        query = BuildQuery(
            id: id,
            query: query,
            name: name,
            version: version,
            implementedAt: implementedAt,
            endedAt: endedAt,
            own: own);
        var count = await query.CountAsync();
        
        return count > 0;
    }

    private IQueryable<Domain.Entities.System> BuildQuery(
        IQueryable<Domain.Entities.System> query,
        Guid? id = null,
        string? name = null,
        string? version = null,
        DateOnly? implementedAt = null,
        DateOnly? endedAt = null,
        bool? own = null)
    {
        if (id != null) query = query.Where(x => x.Id == id);
        if (name != null) query = query.Where(x => x.Name.Contains(name));
        if (version != null) query = query.Where(x => x.Version.Contains(version));
        if (implementedAt != null) query = query.Where(x => x.ImplementedAt == implementedAt);
        if (endedAt != null) query = query.Where(x => x.EndedAt == endedAt);
        if (own != null) query = query.Where(x => x.Own == own);
        
        return query;
    }

    private IQueryable<Domain.Entities.System> BuildOrderBy(
        IQueryable<Domain.Entities.System> query, 
        string? orderByName = null,
        string? orderByVersion = null, 
        string? orderByImplementedAt = null, 
        string? orderByEndedAt = null,
        string? orderByOwn = null)
    {
        query = orderByName switch
        {
            "a" => query.OrderBy(p => p.Name),
            "d" => query.OrderByDescending(p => p.Name),
            _ => query
        };
        query = orderByVersion switch
        {
            "a" => query.OrderBy(p => p.Version),
            "d" => query.OrderByDescending(p => p.Version),
            _ => query
        };
        query = orderByImplementedAt switch
        {
            "a" => query.OrderBy(p => p.ImplementedAt),
            "d" => query.OrderByDescending(p => p.ImplementedAt),
            _ => query
        };
        query = orderByEndedAt switch
        {
            "a" => query.OrderBy(p => p.EndedAt),
            "d" => query.OrderByDescending(p => p.EndedAt),
            _ => query
        };
        query = orderByOwn switch
        {
            "a" => query.OrderBy(p => p.Own),
            "d" => query.OrderByDescending(p => p.Own),
            _ => query
        };
        
        return query;
    }
}