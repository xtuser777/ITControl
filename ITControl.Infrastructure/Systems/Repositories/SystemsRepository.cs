using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Shared.Params;
using ITControl.Domain.Systems.Entities;
using ITControl.Domain.Systems.Interfaces;
using ITControl.Infrastructure.Shared.Contexts;
using ITControl.Infrastructure.Shared.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Systems.Repositories;

public class SystemsRepository(ApplicationDbContext context) 
    : BaseRepository, ISystemsRepository
{
    public async Task<SystemEntity?> FindOneAsync(
        FindOneRepositoryParams @params)
    {
        var (id, includes) = @params;
        query = context.Systems.AsQueryable();
        ApplyIncludes(includes);
        
        return (SystemEntity?)await query
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<SystemEntity>> FindManyAsync(
        FindManyRepositoryParams findManyParams)
    {
        query = context.Systems.AsNoTracking();
        BuildQuery(findManyParams.FindManyProps);
        BuildOrderBy(findManyParams.OrderBy);
        ApplyPagination(findManyParams.Pagination);
        var entities = await query.ToListAsync();
        return entities.Cast<SystemEntity>();
    }

    public async Task CreateAsync(SystemEntity systemEntity)
    {
        await context.Systems.AddAsync(systemEntity);
    }

    public void Update(SystemEntity systemEntity)
    {
        context.Systems.Update(systemEntity);
    }

    public void Delete(SystemEntity systemEntity)
    {
        context.Systems.Remove(systemEntity);
    }

    public async Task<int> CountAsync(Entity countParams)
    {
        query = context.Systems.AsNoTracking();
        BuildQuery(countParams);
        return await query.CountAsync();
    }

    public async Task<bool> ExistsAsync(Entity existsParams)
    {
        var count = await CountAsync(existsParams);
        return count > 0;
    }
}