using ITControl.Domain.Pages.Entities;
using ITControl.Domain.Pages.Interfaces;
using ITControl.Domain.Shared.Params2;
using ITControl.Infrastructure.Contexts;
using ITControl.Infrastructure.Shared.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Pages.Repositories;

public class PagesRepository(ApplicationDbContext context): 
    BaseRepository, IPagesRepository
{
    public async Task<Page?> FindOneAsync(
        FindOneRepositoryParams @params)
    {
        return await context.Pages.FindAsync(@params.Id);
    }

    public async Task<IEnumerable<Page>> FindManyAsync(
        FindManyRepositoryParams @params)
    {
        query = context.Pages.AsNoTracking();
        BuildQuery(@params.FindMany);
        BuildOrderBy(@params.OrderBy);
        ApplyPagination(@params.Pagination);
        return (await query.ToListAsync()).Cast<Page>();
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

    public async Task<int> CountAsync(
        FindManyParams @params)
    {
        query = context.Pages.AsNoTracking();
        BuildQuery(@params);
        return await query.CountAsync();
    }

    public async Task<bool> ExistsAsync(
        FindManyParams @params)
    {
        var count = await CountAsync(@params);
        return count > 0;
    }

    public async Task<bool> ExclusiveAsync(
        FindManyParams @params)
    {
        query = context.Pages.AsNoTracking();
        BuildQuery(@params);
        var count = await query.CountAsync();
        return count > 0;
    }
}