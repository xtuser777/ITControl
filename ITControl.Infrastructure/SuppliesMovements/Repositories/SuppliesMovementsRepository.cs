using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Shared.Params;
using ITControl.Domain.SuppliesMovements.Entities;
using ITControl.Domain.SuppliesMovements.Interfaces;
using ITControl.Infrastructure.Shared.Contexts;
using ITControl.Infrastructure.Shared.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.SuppliesMovements.Repositories;

public class SuppliesMovementsRepository(
    ApplicationDbContext context) : 
    BaseRepository, ISuppliesMovementsRepository
{
    public async Task<SupplyMovement?> FindOneAsync(
        FindOneRepositoryParams findOneParams)
    {
        query = context.SuppliesMovements.AsQueryable();
        ApplyIncludes(findOneParams.Includes);

        return (SupplyMovement?)await query.FirstOrDefaultAsync(
            sm => sm.Id == findOneParams.Id);
    }

    public async Task<IEnumerable<SupplyMovement>> FindManyAsync(
        FindManyRepositoryParams findManyParams)
    {
        query = context.SuppliesMovements
            .Include(sm => sm.Supply)
            .Include(sm => sm.User)
            .Include(sm => sm.Unit)
            .Include(sm => sm.Department)
            .Include(sm => sm.Division)
            .AsNoTracking();
        BuildQuery(findManyParams.FindManyProps);
        BuildOrderBy(findManyParams.OrderBy);
        ApplyPagination(findManyParams.Pagination);
        return (await query.ToListAsync()).Cast<SupplyMovement>();
    }

    public async Task CreateAsync(SupplyMovement supplyMovement)
    {
        await context.SuppliesMovements.AddAsync(supplyMovement);
    }

    public void Update(SupplyMovement supplyMovement)
    {
        context.SuppliesMovements.Update(supplyMovement);
    }

    public void Delete(SupplyMovement supplyMovement)
    {
        context.SuppliesMovements.Remove(supplyMovement);
    }

    public async Task<int> CountAsync(
        Entity countParams)
    {
        query = context.SuppliesMovements.AsNoTracking();
        BuildQuery(countParams);
        return await query.CountAsync();
    }

    public async Task<bool> ExistsAsync(
        Entity existsParams)
    {
        var count = await CountAsync(existsParams);
        return count > 0;
    }
}
