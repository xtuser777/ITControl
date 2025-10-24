using ITControl.Domain.Divisions.Entities;
using ITControl.Domain.Divisions.Interfaces;
using ITControl.Domain.Shared.Params;
using ITControl.Infrastructure.Contexts;
using ITControl.Infrastructure.Shared.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Divisions.Repositories;

public class DivisionsRepository(ApplicationDbContext context) : 
    BaseRepository, IDivisionsRepository
{
    public async Task<Division?> FindOneAsync(
        FindOneRepositoryParams @params)
    {
        query = context.Divisions.AsQueryable();
        ApplyIncludes(@params.Includes);
        
        return (Division?)await query.FirstOrDefaultAsync(x => 
            x.Id == @params.Id);
    }
    
    public async Task<Division?> FindOneAsync(Guid id)
    {
        return await context.Divisions.FindAsync(id);
    }

    public async Task<IEnumerable<Division>> FindManyAsync(
        FindManyRepositoryParams findManyParams,
        OrderByRepositoryParams? orderByParams = null,
        PaginationParams? paginationParams = null)
    {
        query = context.Divisions.AsNoTracking();
        BuildQuery(findManyParams);
        BuildOrderBy(orderByParams);
        ApplyPagination(paginationParams);
        var entities = await query.ToListAsync();
        return entities.Cast<Division>();
    }

    public async Task CreateAsync(Division entity)
    {
        await context.Divisions.AddAsync(entity);
    }

    public void Update(Division entity)
    {
        context.Divisions.Update(entity);
    }

    public void Delete(Division entity)
    {
        context.Divisions.Remove(entity);
    }

    public async Task<int> CountAsync(
        FindManyRepositoryParams @params)
    {
        query = context.Divisions.AsNoTracking();
        BuildQuery(@params);
        
        return await query.CountAsync();
    }

    public async Task<bool> ExistsAsync(
        FindManyRepositoryParams @params)
    {
        var count = await CountAsync(@params);
        return count > 0;
    }

    public async Task<bool> ExclusiveAsync(
        FindManyRepositoryParams @params)
    {
        query = context.Divisions.AsNoTracking();
        BuildQuery(@params);
        var count = await query.CountAsync();
        return count > 0;
    }
}