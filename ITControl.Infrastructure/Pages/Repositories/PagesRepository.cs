using ITControl.Domain.Pages.Entities;
using ITControl.Domain.Pages.Interfaces;
using ITControl.Domain.Pages.Params;
using ITControl.Domain.Shared.Params;
using ITControl.Infrastructure.Contexts;
using ITControl.Infrastructure.Shared.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Pages.Repositories;

public class PagesRepository(ApplicationDbContext context): BaseRepository, IPagesRepository
{
    public async Task<Page?> FindOneAsync(FindOnePagesRepositoryParams @params)
    {
        return await context.Pages.FindAsync(@params.Id);
    }

    public async Task<IEnumerable<Page>> FindManyAsync(
        FindManyPagesRepositoryParams findManyParams,
        OrderByPagesRepositoryParams orderByParams,
        PaginationParams paginationParams)
    {
        query = context.Pages.AsNoTracking();
        BuildQuery(findManyParams);
        BuildOrderBy(orderByParams);
        ApplyPagination(paginationParams);

        var entities = await query.ToListAsync();

        return entities.Cast<Page>();
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
        query = context.Pages.AsNoTracking();
        BuildQuery(@params);
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
        query = context.Pages
            .AsNoTracking()
            .Where(p => p.Id != @params.Id);
        BuildQuery(@params);
        var count = await query.CountAsync();
        
        return count > 0;
    }
}