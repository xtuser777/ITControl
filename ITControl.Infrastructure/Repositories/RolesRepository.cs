using ITControl.Domain.Entities;
using ITControl.Domain.Interfaces;
using ITControl.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Repositories;

public class RolesRepository(ApplicationDbContext context): IRolesRepository
{
    public async Task<Role?> FindOneAsync(
        Guid id, bool? includeRolesPages = null)
    {
        var query = context.Roles.AsQueryable();
        if (includeRolesPages != null)
        {
            query = query.Include(x => x.RolesPages!).ThenInclude(rp => rp.Page);
        }

        return await query.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Role>> FindManyAsync(
        string? name = null, 
        bool? active = null, 
        string? orderByName = null, 
        string? orderByActive = null, 
        int? page = null, 
        int? size = null)
    {
        var query = context.Roles.AsNoTracking();
        query = BuildQuery(query, name, active);
        query = BuildOrderBy(query, orderByName, orderByActive);
        if (page != null && size != null) 
            query = query.Skip((page.Value - 1) * size.Value).Take(size.Value);
        
        return await query.ToListAsync();
    }

    public async Task CreateAsync(Role page)
    {
        await context.Roles.AddAsync(page);
    }

    public void Update(Role page)
    {
        context.Update(page);
    }

    public void Delete(Role page)
    {
        context.Roles.Remove(page);
    }

    public async Task<int> CountAsync(Guid? id = null, string? name = null, bool? active = null)
    {
        var query = context.Roles.AsNoTracking();
        query = BuildQuery(query, name, active);
        return await query.CountAsync();
    }

    public async Task<bool> ExistsAsync(Guid? id = null, string? name = null, bool? active = null)
    {
        var count = await CountAsync(id, name, active);
        
        return count > 0;
    }

    public async Task<bool> ExclusiveAsync(Guid id, string? name = null)
    {
        var query = context.Roles
            .AsNoTracking()
            .Where(p => p.Id != id);
        query = BuildQuery(query, name);
        var count = await query.CountAsync();
        
        return count > 0;
    }

    private IQueryable<Role> BuildQuery(
        IQueryable<Role> query, 
        string? name = null, 
        bool? active = null)
    {
        if (name != null) query = query.Where(r => r.Name.Contains(name));
        if (active != null) query = query.Where(r => r.Active == active);
        
        return query;
    }

    private IQueryable<Role> BuildOrderBy(
        IQueryable<Role> query, 
        string? orderByName = null, 
        string? orderByActive = null)
    {
        query = orderByName switch
        {
            "a" => query.OrderBy(p => p.Name),
            "d" => query.OrderByDescending(p => p.Name),
            _ => query
        };
        query = orderByActive switch
        {
            "a" => query.OrderBy(p => p.Active),
            "d" => query.OrderByDescending(p => p.Active),
            _ => query
        };
        
        return query;
    }
}