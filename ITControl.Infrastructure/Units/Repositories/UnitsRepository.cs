using ITControl.Domain.Shared.Params;
using ITControl.Domain.Units.Entities;
using ITControl.Domain.Units.Interfaces;
using ITControl.Domain.Units.Params;
using ITControl.Infrastructure.Contexts;
using ITControl.Infrastructure.Shared.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Units.Repositories;

public class UnitsRepository(ApplicationDbContext context) : BaseRepository, IUnitsRepository
{
    public async Task<Unit?> FindOneAsync(FindOneUnitsRepositoryParams @params)
    {
        return await context.Units.SingleOrDefaultAsync(x => x.Id == @params.Id);
    }

    public async Task<IEnumerable<Unit>> FindManyAsync(
        FindManyUnitsRepositoryParams findManyParams,
        OrderByUnitsRepositoryParams? orderByParams = null,
        PaginationParams? paginationParams = null)
    {
        query = context.Units.AsNoTracking();
        BuildQuery(findManyParams);
        BuildOrderBy(orderByParams);
        ApplyPagination(paginationParams);

        var entities = await query.ToListAsync();

        return from entity in entities
            select (Unit)entity;
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

    public async Task<int> CountAsync(CountUnitsRepositoryParams @params)
    {
        query = context.Units.AsNoTracking();
        BuildQuery(@params);
        
        return await query.CountAsync();
    }

    public async Task<bool> ExistsAsync(ExistsUnitsRepositoryParams @params)
    {
        var count = await CountAsync(@params);
        
        return count > 0;
    }

    public async Task<bool> ExclusiveAsync(ExclusiveUnitsRepositoryParams @params)
    {
        query = context.Units.AsNoTracking();
        query = query.Where(x => x.Id != @params.Id);
        @params.Id = null;
        BuildQuery(@params);
        var count = await query.CountAsync();
        
        return count > 0;
    }
}