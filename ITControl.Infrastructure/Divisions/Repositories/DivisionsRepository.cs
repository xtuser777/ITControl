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
        FindOneRepositoryParams parameters)
    {
        query = context.Divisions.AsQueryable();
        ApplyIncludes(parameters.Includes);
        
        return (Division?)await query.FirstOrDefaultAsync(x => 
            x.Id == parameters.Id);
    }
    
    public async Task<Division?> FindOneAsync(Guid id)
    {
        return await context.Divisions.FindAsync(id);
    }

    public async Task<IEnumerable<Division>> FindManyAsync(
        FindManyRepositoryParams parameters)
    {
        query = context.Divisions.AsNoTracking();
        BuildQuery(parameters.FindMany);
        BuildOrderBy(parameters.OrderBy);
        ApplyPagination(parameters.Pagination);
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
        FindManyParams parameters)
    {
        query = context.Divisions.AsNoTracking();
        BuildQuery(parameters);
        
        return await query.CountAsync();
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
        query = context.Divisions.AsNoTracking();
        BuildQuery(parameters);
        var count = await query.CountAsync();
        return count > 0;
    }
}