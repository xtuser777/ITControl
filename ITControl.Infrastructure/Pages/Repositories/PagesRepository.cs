using ITControl.Domain.Pages.Entities;
using ITControl.Domain.Pages.Interfaces;
using ITControl.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Pages.Repositories;

public class PagesRepository(ApplicationDbContext context): IPagesRepository
{
    public async Task<Page?> FindOneAsync(IFindOnePagesRepositoryParams @params)
    {
        return await context.Pages.FindAsync(@params.Id);
    }

    public async Task<IEnumerable<Page>> FindManyAsync(IFindManyPagesRepositoryParams @params)
    {
        var query = context.Pages.AsNoTracking();
        if (@params.Name != null) query = query.Where(p => p.Name.Contains(@params.Name));
        query = @params.OrderByName switch
        {
            "a" => query.OrderBy(p => p.Name),
            "d" => query.OrderByDescending(p => p.Name),
            _ => query
        };
        if (@params.Page != null && @params.Size != null) 
            query = query.Skip((@params.Page.Value - 1) * @params.Size.Value).Take(@params.Size.Value);
        
        return await query.ToListAsync();
    }

    public async Task CreateAsync(Page page)
    {
        await context.Pages.AddAsync(page);
    }

    public void Update(Page page)
    {
        context.Pages.Update(page);
    }

    public void Delete(Page page)
    {
        context.Pages.Remove(page);
    }

    public async Task<int> CountAsync(ICountPagesRepositoryParams @params)
    {
        var query = context.Pages.AsNoTracking();
        if (@params.Id != null) query = query.Where(p => p.Id == @params.Id);
        if (@params.Name != null) query = query.Where(p => p.Name.Contains(@params.Name));
        var count = await query.CountAsync();
        
        return count;
    }

    public async Task<bool> ExistsAsync(IExistsPagesRepositoryParams @params)
    {
        var count = await CountAsync(@params);
        
        return count > 0;
    }

    public async Task<bool> ExclusiveAsync(IExclusivePagesRepositoryParams @params)
    {
        var query = context.Pages
            .AsNoTracking()
            .Where(p => p.Id != @params.Id);
        if (@params.Name != null) query = query.Where(p => p.Name.Contains(@params.Name));
        var count = await query.CountAsync();
        
        return count > 0;
    }
}

public class FindOnePagesRepositoryParams : IFindOnePagesRepositoryParams
{
    public Guid? Id { get; set; }
}

public class FindManyPagesRepositoryParams : IFindManyPagesRepositoryParams
{
    public string? Name { get; set; }
    public string? OrderByName { get; set; }
    public int? Page { get; set; }
    public int? Size { get; set; }
}

public class CountPagesRepositoryParams : ICountPagesRepositoryParams
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }
}

public class ExistsPagesRepositoryParams : IExistsPagesRepositoryParams
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }
}

public class ExclusivePagesRepositoryParams : IExclusivePagesRepositoryParams
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
}