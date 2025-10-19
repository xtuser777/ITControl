using ITControl.Domain.Positions.Entities;
using ITControl.Domain.Positions.Interfaces;
using ITControl.Domain.Positions.Params;
using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Shared.Params;
using ITControl.Infrastructure.Contexts;
using ITControl.Infrastructure.Shared.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Positions.Repositories;

public class PositionsRepository(ApplicationDbContext context) 
    : BaseRepository, IPositionsRepository
{
    public async Task<Entity?> FindOneAsync(IFindOneRepositoryParams @params)
    {
        return await context.Positions.FindAsync(
            ((FindOnePositionRepositoryParams)@params).Id);
    }

    public async Task<IEnumerable<Entity>> FindManyAsync(
        IFindManyRepositoryParams findManyParams,
        IOrderByRepositoryParams? orderByParams,
        PaginationParams? paginationParams)
    {
        query = context.Positions.AsNoTracking();
        BuildQuery((FindManyPositionsRepositoryParams)findManyParams);
        BuildOrderBy((OrderByPositionsRepositoryParams?)orderByParams);
        ApplyPagination(paginationParams);

        var entities = await query.ToListAsync();

        return entities.Cast<Position>();
    }

    public async Task CreateAsync(Entity entity)
    {
        await context.Positions.AddAsync((Position)entity);
    }

    public void Update(Entity entity)
    {
        context.Positions.Update((Position)entity);
    }

    public void Delete(Entity entity)
    {
        context.Positions.Remove((Position)entity);
    }

    public async Task<int> CountAsync(ICountRepositoryParams @params)
    {
        query = context.Positions.AsNoTracking();
        BuildQuery((CountPositionsRepositoryParams)@params);
        var count = await query.CountAsync();
        
        return count;
    }

    public async Task<bool> ExistsAsync(IExistsRepositoryParams @params)
    {
        var count = await CountAsync((ExistsPositionsRepositoryParams)@params);
        
        return count > 0;
    }

    public async Task<bool> ExclusiveAsync(IExclusiveRepositoryParams @params)
    {
        query = context.Positions.AsNoTracking();
        query = query.Where(p => p.Id != ((ExclusivePositionsRepositoryParams)@params).ExcludeId);
        BuildQuery((ExclusivePositionsRepositoryParams)@params);
        var count = await query.CountAsync();
        
        return count > 0;
    }
}