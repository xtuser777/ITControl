using ITControl.Domain.Shared.Params;
using ITControl.Domain.Systems.Interfaces;
using ITControl.Infrastructure.Contexts;
using ITControl.Infrastructure.Shared.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Systems.Repositories;

public class SystemsRepository(ApplicationDbContext context) 
    : BaseRepository, ISystemsRepository
{
    public async Task<Domain.Systems.Entities.System?> FindOneAsync(
        FindOneRepositoryParams @params)
    {
        var (id, includes) = @params;
        query = context.Systems.AsQueryable();
        ApplyIncludes(includes);
        
        return (Domain.Systems.Entities.System?)await query
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Domain.Systems.Entities.System>> FindManyAsync(
        FindManyRepositoryParams findManyParams)
    {
        query = context.Systems.AsNoTracking();
        BuildQuery(findManyParams.FindMany);
        BuildOrderBy(findManyParams.OrderBy);
        ApplyPagination(findManyParams.Pagination);
        var entities = await query.ToListAsync();
        return entities.Cast<Domain.Systems.Entities.System>();
    }

    public async Task CreateAsync(Domain.Systems.Entities.System system)
    {
        await context.Systems.AddAsync(system);
    }

    public void Update(Domain.Systems.Entities.System system)
    {
        context.Systems.Update(system);
    }

    public void Delete(Domain.Systems.Entities.System system)
    {
        context.Systems.Remove(system);
    }

    public async Task<int> CountAsync(FindManyParams countParams)
    {
        query = context.Systems.AsNoTracking();
        BuildQuery(countParams);
        return await query.CountAsync();
    }

    public async Task<bool> ExistsAsync(FindManyParams existsParams)
    {
        var count = await CountAsync(existsParams);
        return count > 0;
    }
}