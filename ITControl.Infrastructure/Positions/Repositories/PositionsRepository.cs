using ITControl.Domain.Positions.Entities;
using ITControl.Domain.Positions.Interfaces;
using ITControl.Domain.Positions.Params;
using ITControl.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Positions.Repositories;

public class PositionsRepository(ApplicationDbContext context) : IPositionsRepository
{
    public async Task<Position?> FindOneAsync(FindOnePositionRepositoryParams @params)
    {
        return await context.Positions.FindAsync(@params.Id);
    }

    public async Task<IEnumerable<Position>> FindManyAsync(FindManyPositionsRepositoryParams @params)
    {
        var (page, size) = @params;
        var query = context.Positions.AsNoTracking();
        query = BuildQuery(new BuildQueryPositionsRepositoryParams
        {
            Query = query,
            Params = @params
        });
        query = BuildOrderBy(new BuildOrderByPositionsRepositoryParams
        {
            Query = query,
            Params = @params
        });
        if (page != null && size != null) 
            query = query.Skip((page.Value - 1) * size.Value).Take(size.Value);
        
        return await query.ToListAsync();
    }

    public async Task CreateAsync(Position position)
    {
        await context.Positions.AddAsync(position);
    }

    public void Update(Position position)
    {
        context.Positions.Update(position);
    }

    public void Delete(Position position)
    {
        context.Positions.Remove(position);
    }

    public async Task<int> CountAsync(CountPositionsRepositoryParams @params)
    {
        var query = context.Positions.AsNoTracking();
        query = BuildQuery(new BuildQueryPositionsRepositoryParams
        {
            Query = query,
            Params = @params
        });
        var count = await query.CountAsync();
        
        return count;
    }

    public async Task<bool> ExistsAsync(ExistsPositionsRepositoryParams @params)
    {
        var count = await CountAsync(@params);
        
        return count > 0;
    }

    public async Task<bool> ExclusiveAsync(ExclusivePositionsRepositoryParams @params)
    {
        var query = context.Positions
            .AsNoTracking()
            .Where(p => p.Id != @params.Id);
        if (@params.Description != null) 
            query = query.Where(p => p.Description.Contains(@params.Description));
        var count = await query.CountAsync();
        
        return count > 0;
    }

    private static IQueryable<Position> BuildQuery(BuildQueryPositionsRepositoryParams @queryParams)
    {
        var (query, @params) = @queryParams;
        if (@params.Id != null) 
            query = query.Where(p => p.Id == @params.Id);
        if (@params.Description != null) 
            query = query.Where(p => p.Description.Contains(@params.Description));

        return query;
    }

    private static IQueryable<Position> BuildOrderBy(BuildOrderByPositionsRepositoryParams @orderByParams)
    {
        var (query, @params) = @orderByParams;
        query = @params.OrderByDescription switch
        {
            "a" => query.OrderBy(p => p.Description),
            "d" => query.OrderByDescending(p => p.Description),
            _ => query
        };

        return query;
    }
}