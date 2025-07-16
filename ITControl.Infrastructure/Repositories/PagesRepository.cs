using ITControl.Domain.Entities;
using ITControl.Domain.Interfaces;
using ITControl.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Repositories;

public class PagesRepository(ApplicationDbContext context): IPagesRepository
{
    public async Task<Page?> FindOneAsync(Guid id)
    {
        var page = await context.Pages.FindAsync(id);
        return page;
    }

    public async Task<IEnumerable<Page>> FindManyAsync(string? name = null, string? orderByName = null, int? page = null, int? size = null)
    {
        var query = context.Pages.AsNoTracking();
        if (name != null) query = query.Where(p => p.Name.Contains(name));
        query = orderByName switch
        {
            "a" => query.OrderBy(p => p.Name),
            "d" => query.OrderByDescending(p => p.Name),
            _ => query
        };
        if (page != null && size != null) query = query.Skip((page.Value - 1) * size.Value).Take(size.Value);
        
        return await query.ToListAsync();
    }

    public async Task CreateAsync(Page page)
    {
        await context.Pages.AddAsync(page);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Page page)
    {
        context.Update(page);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Page page)
    {
        context.Pages.Remove(page);
        await context.SaveChangesAsync();
    }

    public async Task<int> CountAsync(Guid? id = null, string? name = null)
    {
        var query = context.Pages.AsNoTracking();
        if (id != null) query = query.Where(p => p.Id == id);
        if (name != null) query = query.Where(p => p.Name.Contains(name));
        var count = await query.CountAsync();
        
        return count;
    }

    public async Task<bool> ExistAsync(Guid? id = null, string? name = null)
    {
        var count = await CountAsync(id, name);
        
        return count > 0;
    }

    public async Task<bool> ExclusiveAsync(Guid id, string? name = null)
    {
        var query = context.Pages
            .AsNoTracking()
            .Where(p => p.Id != id);
        if (name != null) query = query.Where(p => p.Name.Contains(name));
        var count = await query.CountAsync();
        
        return count > 0;
    }
}