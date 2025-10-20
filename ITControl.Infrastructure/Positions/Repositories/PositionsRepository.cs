using ITControl.Domain.Positions.Entities;
using ITControl.Domain.Positions.Interfaces;
using ITControl.Domain.Positions.Params;
using ITControl.Domain.Shared.Params;
using ITControl.Infrastructure.Contexts;
using ITControl.Infrastructure.Shared.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Positions.Repositories;

public class PositionsRepository(ApplicationDbContext context) 
    : BaseRepository, IPositionsRepository
{
    public async Task<Position?> FindOneAsync(FindOneRepositoryParams @params)
    {
        return await context.Positions.FindAsync(@params.Id);
    }

    public async Task<IEnumerable<Position>> FindManyAsync(
        FindManyRepositoryParams findManyParams,
        OrderByRepositoryParams? orderByParams,
        PaginationParams? paginationParams)
    {
        query = context.Positions.AsNoTracking();
        BuildQuery((FindManyPositionsRepositoryParams)findManyParams);
        BuildOrderBy((OrderByPositionsRepositoryParams?)orderByParams);
        ApplyPagination(paginationParams);
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

    public async Task<int> CountAsync(FindManyRepositoryParams @params)
    {
        query = context.Positions.AsNoTracking();
        BuildQuery((CountPositionsRepositoryParams)@params);
        var count = await query.CountAsync();
        
        return count;
    }

    public async Task<bool> ExistsAsync(FindManyRepositoryParams @params)
    {
        var count = await CountAsync((ExistsPositionsRepositoryParams)@params);
        
        return count > 0;
    }

    public async Task<bool> ExclusiveAsync(FindManyRepositoryParams @params)
    {
        query = context.Positions.AsNoTracking();
        BuildQuery((ExclusivePositionsRepositoryParams)@params);
        var count = await query.CountAsync();
        
        return count > 0;
    }
}