using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Shared.Params;
using ITControl.Domain.Supplies.Entities;
using ITControl.Domain.Supplies.Interfaces;
using ITControl.Infrastructure.Shared.Contexts;
using ITControl.Infrastructure.Shared.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Supplies.Repositories;

public class SuppliesRepository(
    ApplicationDbContext context) : BaseRepository, ISuppliesRepository
{
    public async Task<Supply?> FindOneAsync(
        FindOneRepositoryParams findOneParams)
    {
        return await context.Supplies
            .FindAsync(findOneParams.Id);
    }

    public async Task<IEnumerable<Supply>> FindManyAsync(
        FindManyRepositoryParams findManyParams)
    {
        query = context.Supplies.AsNoTracking();
        BuildQuery(findManyParams.FindManyProps);
        BuildOrderBy(findManyParams.OrderBy);
        ApplyPagination(findManyParams.Pagination);
        return (await query.ToListAsync()).Cast<Supply>();
    }

    public async Task CreateAsync(Supply supply)
    {
        await context.Supplies.AddAsync(supply);
    }

    public void Update(Supply supply)
    {
        context.Supplies.Update(supply);
    }

    public void Delete(Supply supply)
    {
        context.Supplies.Remove(supply);
    }

    public async Task<int> CountAsync(Entity @params)
    {
        query = context.Supplies.AsNoTracking();
        BuildQuery(@params);
        return await query.CountAsync();
    }

    public async Task<bool> ExistsAsync(Entity @params)
    {
        var count = await CountAsync(@params);
        return count > 0;
    }
}
