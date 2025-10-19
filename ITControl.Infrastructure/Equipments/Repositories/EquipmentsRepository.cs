using ITControl.Domain.Equipments.Entities;
using ITControl.Domain.Equipments.Interfaces;
using ITControl.Domain.Shared.Params;
using ITControl.Infrastructure.Contexts;
using ITControl.Infrastructure.Shared.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Equipments.Repositories;

public class EquipmentsRepository(ApplicationDbContext context) : 
    BaseRepository, IEquipmentsRepository
{
    public async Task<Equipment?> FindOneAsync(FindOneRepositoryParams @params)
    {
        var (id, includes) = @params;
        query = context.Equipments.AsQueryable();
        ApplyIncludes(includes);
        
        return (Equipment?)await query
            .FirstOrDefaultAsync(x => x.Id == id);
    }
    
    public async Task<Equipment?> FindOneAsync(Guid id)
    {
        return await context.Equipments.FindAsync(id);
    }

    public async Task<IEnumerable<Equipment>> FindManyAsync(
        FindManyRepositoryParams findManyParams,
        OrderByRepositoryParams? orderByParams = null,
        PaginationParams? paginationParams = null)
    {
        query = context.Equipments.AsNoTracking();
        BuildQuery(findManyParams);
        BuildOrderBy(orderByParams);
        ApplyPagination(paginationParams);
        var entities = await query.ToListAsync();
        return entities.Cast<Equipment>();
    }

    public async Task CreateAsync(Equipment equipment)
    {
        await context.Equipments.AddAsync(equipment);
    }

    public void Update(Equipment equipment)
    {
        context.Equipments.Update(equipment);
    }

    public void Delete(Equipment equipment)
    {
        context.Equipments.Remove(equipment);
    }

    public async Task<int> CountAsync(FindManyRepositoryParams @params)
    {
        query = context.Equipments.AsNoTracking();
        BuildQuery(@params);
        return await query.CountAsync();
    }

    public async Task<bool> ExistsAsync(FindManyRepositoryParams @params)
    {
        var count = await CountAsync(@params);
        
        return count > 0;
    }

    public async Task<bool> ExclusiveAsync(FindManyRepositoryParams @params)
    {
        query = context.Equipments.AsNoTracking();
        BuildQuery(@params);
        var count = await query.CountAsync();
        
        return count > 0;
    }
}