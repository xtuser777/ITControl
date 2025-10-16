using ITControl.Domain.Shared.Params;
using ITControl.Domain.Systems.Interfaces;
using ITControl.Domain.Systems.Params;
using ITControl.Infrastructure.Contexts;
using ITControl.Infrastructure.Shared.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Systems.Repositories;

public class SystemsRepository(ApplicationDbContext context) 
    : BaseRepository, ISystemsRepository
{
    public async Task<Domain.Systems.Entities.System?> FindOneAsync(FindOneSystemsRepositoryParams @params)
    {
        var (id, includeContract) = @params;
        var query = context.Systems.AsQueryable();
        if (includeContract is true) 
            query = query.Include(x => x.Contract);
        
        return await query.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Domain.Systems.Entities.System>> FindManyAsync(
        FindManySystemsRepositoryParams findManyParams,
        OrderBySystemsRepositoryParams orderByParams,
        PaginationParams paginationParams)
    {
        query = context.Systems.AsNoTracking();
        BuildQuery(findManyParams);
        BuildOrderBy(orderByParams);
        ApplyPagination(paginationParams);

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

    public async Task<int> CountAsync(CountSystemsRepositoryParams @params)
    {
        query = context.Systems.AsNoTracking();
        BuildQuery(@params);
        
        return await query.CountAsync();
    }

    public async Task<bool> ExistsAsync(ExistsSystemsRepositoryParams @params)
    {
        var count = await CountAsync(@params);
        
        return count > 0;
    }
}