using ITControl.Domain.Positions.Entities;
using ITControl.Domain.Positions.Interfaces;
using ITControl.Domain.Positions.Params;
using ITControl.Domain.Shared.Params2;
using ITControl.Infrastructure.Contexts;
using ITControl.Infrastructure.Shared.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Positions.Repositories;

public class PositionsRepository(ApplicationDbContext context) 
    : BaseRepository, IPositionsRepository
{
    public async Task<Position?> FindOneAsync(
        FindOneRepositoryParams parameters)
    {
        return await context.Positions
            .FindAsync(parameters.Id);
    }

    public async Task<IEnumerable<Position>> FindManyAsync(
        FindManyRepositoryParams parameters)
    {
        query = context.Positions.AsNoTracking();
        BuildQuery(parameters.FindMany);
        BuildOrderBy(parameters.OrderBy);
        ApplyPagination(parameters.Pagination);
        return (await query.ToListAsync()).Cast<Position>();

    }

    public async Task CreateAsync(Position entity)
    {
        await context.Positions.AddAsync(entity);
    }

    public void Update(Position entity)
    {
        context.Positions.Update(entity);
    }

    public void Delete(Position entity)
    {
        context.Positions.Remove(entity);
    }

    public async Task<int> CountAsync(
        FindManyParams parameters)
    {
        query = context.Positions.AsNoTracking();
        BuildQuery(parameters);
        var count = await query.CountAsync();
        
        return count;
    }

    public async Task<bool> ExistsAsync(
        FindManyParams parameters)
    {
        var count = await CountAsync(parameters);
        
        return count > 0;
    }

    public async Task<bool> ExclusiveAsync(
        FindManyParams parameters)
    {
        query = context.Positions.AsNoTracking();
        BuildQuery(parameters);
        var count = await query.CountAsync();
        
        return count > 0;
    }
}