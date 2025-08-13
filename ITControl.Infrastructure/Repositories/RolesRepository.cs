using ITControl.Domain.Entities;
using ITControl.Domain.Interfaces;
using ITControl.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Repositories;

public class RolesRepository(ApplicationDbContext context): IRolesRepository
{
    public async Task<Role?> FindOneAsync(Guid id, bool? includeRolesPages = null)
    {
        var query = context.Roles.AsQueryable();
        if (includeRolesPages != null) query = query.Include(x => x.RolesPages);
        var page = await query.Where(x => x.Id == id).FirstOrDefaultAsync();
        
        return page;
    }

    public async Task<IEnumerable<Role>> FindManyAsync(string? name = null, bool? active = null, string? orderByName = null, string? orderByActive = null, int? page = null, int? size = null)
    {
        var query = context.Roles.AsNoTracking();
        if (name != null) query = query.Where(r => r.Name.Contains(name));
        if (active != null) query = query.Where(r => r.Active == active);
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
        if (page != null && size != null) query = query.Skip((page.Value - 1) * size.Value).Take(size.Value);
        
        return await query.ToListAsync();
    }

    public async Task CreateAsync(Role page)
    {
        await context.Roles.AddAsync(page);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Role page)
    {
        context.Update(page);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Role page)
    {
        context.Roles.Remove(page);
        await context.SaveChangesAsync();
    }

    public async Task<int> CountAsync(Guid? id = null, string? name = null, bool? active = null)
    {
        var query = context.Roles.AsNoTracking();
        if (id != null) query = query.Where(r => r.Id == id);
        if (name != null) query = query.Where(r => r.Name.Contains(name));
        if (active != null) query = query.Where(r => r.Active == active);
        var count = await query.CountAsync();
        
        return count;
    }

    public async Task<bool> ExistAsync(Guid? id = null, string? name = null, bool? active = null)
    {
        var count = await CountAsync(id, name, active);
        
        return count > 0;
    }

    public async Task<bool> ExclusiveAsync(Guid id, string? name = null)
    {
        var query = context.Roles
            .AsNoTracking()
            .Where(p => p.Id != id);
        if (name != null) query = query.Where(p => p.Name.Contains(name));
        var count = await query.CountAsync();
        
        return count > 0;
    }
}