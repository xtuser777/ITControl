using ITControl.Domain.Shared.Params2;
using ITControl.Domain.Units.Entities;
using ITControl.Domain.Units.Interfaces;
using ITControl.Infrastructure.Contexts;
using ITControl.Infrastructure.Shared.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Units.Repositories;

public class UnitsRepository(ApplicationDbContext context) : 
    BaseRepository, IUnitsRepository
{
    public async Task<Unit?> FindOneAsync(FindOneRepositoryParams parameters)
    {
        return await context.Units
            .SingleOrDefaultAsync(x => x.Id == parameters.Id);
    }

    public async Task<IEnumerable<Unit>> FindManyAsync(
        FindManyRepositoryParams findManyParams)
    {
        query = context.Units.AsNoTracking();
        BuildQuery(findManyParams.FindMany);
        BuildOrderBy(findManyParams.OrderBy);
        ApplyPagination(findManyParams.Pagination);
        return (await query.ToListAsync()).Cast<Unit>();
    }

    public async Task CreateAsync(Unit unit)
    {
        await context.Units.AddAsync(unit);
    }

    public void Update(Unit unit)
    {
        context.Units.Update(unit);
    }

    public void Delete(Unit unit)
    {
        context.Units.Remove(unit);
    }

    public async Task<int> CountAsync(FindManyParams parameters)
    {
        query = context.Units.AsNoTracking();
        BuildQuery(parameters);
        return await query.CountAsync();
    }

    public async Task<bool> ExistsAsync(FindManyParams parameters)
    {
        var count = await CountAsync(parameters);
        return count > 0;
    }

    public async Task<bool> ExclusiveAsync(FindManyParams parameters)
    {
        query = context.Units.AsNoTracking();
        BuildQuery(parameters);
        var count = await query.CountAsync();
        return count > 0;
    }
}