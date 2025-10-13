using ITControl.Domain.Pages.Entities;
using ITControl.Domain.Pages.Interfaces;
using ITControl.Domain.Pages.Params;
using ITControl.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Pages.Repositories;

public class PagesRepository(ApplicationDbContext context): IPagesRepository
{
    public async Task<Page?> FindOneAsync(FindOnePagesRepositoryParams @params)
    {
        return await context.Pages.FindAsync(@params.Id);
    }

    public async Task<IEnumerable<Page>> FindManyAsync(FindManyPagesRepositoryParams @params)
    {
        var query = context.Pages.AsNoTracking();
        query = BuildQuery(new BuildQueryPagesRepositoryParams()
        {
            Query = query,
            Params = @params
        });
        query = BuildOrderBy(new BuildOrderByPagesRepositoryParams()
        {
            Query = query,
            Params = @params
        });
        if (@params is { Page: not null, Size: not null }) 
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

    public async Task<int> CountAsync(CountPagesRepositoryParams @params)
    {
        var query = context.Pages.AsNoTracking();
        query = BuildQuery(new BuildQueryPagesRepositoryParams()
        {
            Query = query,
            Params = @params
        });
        var count = await query.CountAsync();
        
        return count;
    }

    public async Task<bool> ExistsAsync(ExistsPagesRepositoryParams @params)
    {
        var count = await CountAsync(@params);
        
        return count > 0;
    }

    public async Task<bool> ExclusiveAsync(ExclusivePagesRepositoryParams @params)
    {
        var query = context.Pages
            .AsNoTracking()
            .Where(p => p.Id != @params.Id);
        if (@params.Name != null) query = query.Where(p => p.Name.Contains(@params.Name));
        var count = await query.CountAsync();
        
        return count > 0;
    }

    private static IQueryable<Page> BuildQuery(BuildQueryPagesRepositoryParams @queryParams)
    {
        var (query, @params) = @queryParams;
        if (@params.Id != null) query = query.Where(p => p.Id == @params.Id);
        if (@params.Name != null) query = query.Where(p => p.Name.Contains(@params.Name));

        return query;
    }

    private static IQueryable<Page> BuildOrderBy(BuildOrderByPagesRepositoryParams @orderByParams)
    {
        var (query, @params) = @orderByParams;
        query = @params.OrderByName switch
        {
            "a" => query.OrderBy(p => p.Name),
            "d" => query.OrderByDescending(p => p.Name),
            _ => query
        };
        
        return query;
    }
}