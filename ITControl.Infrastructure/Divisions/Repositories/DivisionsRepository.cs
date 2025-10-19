using ITControl.Domain.Divisions.Entities;
using ITControl.Domain.Divisions.Interfaces;
using ITControl.Domain.Divisions.Params;
using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Shared.Params;
using ITControl.Infrastructure.Contexts;
using ITControl.Infrastructure.Shared.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Divisions.Repositories;

public class DivisionsRepository(ApplicationDbContext context) : 
    BaseRepository, IDivisionsRepository
{
    public async Task<Entity?> FindOneAsync(IFindOneRepositoryParams @params)
    {
        query = context.Divisions.AsQueryable();
        ApplyIncludes(((FindOneDivisionsRepositoryParams)@params).Includes);
        
        return await query.FirstOrDefaultAsync(x => 
            x.Id == ((FindOneDivisionsRepositoryParams)@params).Id);
    }
    
    public async Task<Entity?> FindOneAsync(Guid id)
    {
        return await context.Divisions.FindAsync(id);
    }

    public async Task<IEnumerable<Entity>> FindManyAsync(
        IFindManyRepositoryParams findManyParams,
        IOrderByRepositoryParams? orderByParams = null,
        PaginationParams? paginationParams = null)
    {
        query = context.Divisions.AsNoTracking();
        BuildQuery((FindManyDivisionsRepositoryParams)findManyParams);
        BuildOrderBy((OrderByDivisionsRepositoryParams?)orderByParams);
        ApplyPagination(paginationParams);
        
        return await query.ToListAsync();
    }

    public async Task CreateAsync(Entity entity)
    {
        await context.Divisions.AddAsync((Division)entity);
    }

    public void Update(Entity entity)
    {
        context.Divisions.Update((Division)entity);
    }

    public void Delete(Entity entity)
    {
        context.Divisions.Remove((Division)entity);
    }

    public async Task<int> CountAsync(ICountRepositoryParams @params)
    {
        query = context.Divisions.AsNoTracking();
        BuildQuery((CountDivisionsRepositoryParams)@params);
        
        return await query.CountAsync();
    }

    public async Task<bool> ExistsAsync(IExistsRepositoryParams @params)
    {
        var count = await CountAsync(@params);
        
        return count > 0;
    }

    public async Task<bool> ExclusiveAsync(IExclusiveRepositoryParams @params)
    {
        query = context.Divisions.AsNoTracking();
        query = query.Where(x => 
            x.Id != ((ExclusiveDivisionsRepositoryParams)@params).ExcludeId);
        BuildQuery((ExclusiveDivisionsRepositoryParams)@params);
        var count = await query.CountAsync();
        
        return count > 0;
    }
}