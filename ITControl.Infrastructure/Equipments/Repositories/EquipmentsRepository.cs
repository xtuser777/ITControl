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
    public async Task<Equipment?> FindOneAsync(
        FindOneRepositoryParams parameters)
    {
        var (id, includes) = parameters;
        query = context.Equipments.AsQueryable();
        ApplyIncludes(includes);
        return (Equipment?)await query
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Equipment>> FindManyAsync(
        FindManyRepositoryParams parameters)
    {
        query = context.Equipments.AsNoTracking();
        BuildQuery(parameters.FindMany);
        BuildOrderBy(parameters.OrderBy);
        ApplyPagination(parameters.Pagination);
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

    public async Task<int> CountAsync(
        FindManyParams parameters)
    {
        query = context.Equipments.AsNoTracking();
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
        query = context.Equipments.AsNoTracking();
        BuildQuery(parameters);
        var count = await query.CountAsync();
        return count > 0;
    }
}