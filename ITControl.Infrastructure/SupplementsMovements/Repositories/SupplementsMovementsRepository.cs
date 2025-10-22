using ITControl.Domain.Shared.Params2;
using ITControl.Domain.SupplementsMovements.Entities;
using ITControl.Domain.SupplementsMovements.Interfaces;
using ITControl.Infrastructure.Contexts;
using ITControl.Infrastructure.Shared.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.SupplementsMovements.Repositories;

public class SupplementsMovementsRepository(
    ApplicationDbContext context) : 
    BaseRepository, ISupplementsMovementsRepository
{
    public async Task<SupplementMovement?> FindOneAsync(
        FindOneRepositoryParams findOneParams)
    {
        query = context.SupplementsMovements.AsQueryable();
        ApplyIncludes(findOneParams.Includes);

        return (SupplementMovement?)await query.FirstOrDefaultAsync(
            sm => sm.Id == findOneParams.Id);
    }

    public async Task<IEnumerable<SupplementMovement>> FindManyAsync(
        FindManyRepositoryParams findManyParams)
    {
        query = context.SupplementsMovements
            .Include(sm => sm.Supplement)
            .Include(sm => sm.User)
            .Include(sm => sm.Unit)
            .Include(sm => sm.Department)
            .Include(sm => sm.Division)
            .AsNoTracking();
        BuildQuery(findManyParams.FindMany);
        BuildOrderBy(findManyParams.OrderBy);
        ApplyPagination(findManyParams.Pagination);
        return (await query.ToListAsync()).Cast<SupplementMovement>();
    }

    public async Task CreateAsync(SupplementMovement supplementMovement)
    {
        await context.SupplementsMovements.AddAsync(supplementMovement);
    }

    public void Update(SupplementMovement supplementMovement)
    {
        context.SupplementsMovements.Update(supplementMovement);
    }

    public void Delete(SupplementMovement supplementMovement)
    {
        context.SupplementsMovements.Remove(supplementMovement);
    }

    public async Task<int> CountAsync(
        FindManyParams countParams)
    {
        query = context.SupplementsMovements.AsNoTracking();
        BuildQuery(countParams);
        return await query.CountAsync();
    }

    public async Task<bool> ExistsAsync(
        FindManyParams existsParams)
    {
        var count = await CountAsync(existsParams);
        return count > 0;
    }
}
