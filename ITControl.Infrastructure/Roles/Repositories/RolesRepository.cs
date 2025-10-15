using ITControl.Domain.Roles.Entities;
using ITControl.Domain.Roles.Interfaces;
using ITControl.Domain.Roles.Params;
using ITControl.Domain.Shared.Params;
using ITControl.Infrastructure.Contexts;
using ITControl.Infrastructure.Shared.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Roles.Repositories;

public class RolesRepository(ApplicationDbContext context)
    : BaseRepository, IRolesRepository
{
    public async Task<Role?> FindOneAsync(FindOneRolesRepositoryParams @params)
    {
        var (id, includes) = @params;
        query = context.Roles.AsQueryable();
        ApplyIncludes(includes);

        return (Role?)await query.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Role>> FindManyAsync(
        FindManyRolesRepositoryParams findManyRolesParams,
        OrderByRolesRepositoryParams? orderByRolesParams = null,
        PaginationParams? paginationParams = null)
    {
        query = context.Roles.AsNoTracking();
        BuildQuery(findManyRolesParams);
        BuildOrderBy(orderByRolesParams);
        ApplyPagination(paginationParams);

        var entities = await query.ToListAsync();

        return from entity in entities select (Role)entity;
    }

    public async Task CreateAsync(Role page)
    {
        await context.Roles.AddAsync(page);
    }

    public void Update(Role page)
    {
        context.Update(page);
    }

    public void Delete(Role page)
    {
        context.Roles.Remove(page);
    }

    public async Task<int> CountAsync(CountRolesRepositoryParams @params)
    {
        query = context.Roles.AsNoTracking();
        BuildQuery(@params);
        return await query.CountAsync();
    }

    public async Task<bool> ExistsAsync(ExistsRolesRepositoryParams @params)
    {
        var count = await CountAsync(@params);
        
        return count > 0;
    }

    public async Task<bool> ExclusiveAsync(ExclusiveRolesRepositoryParams @params)
    {
        query = context.Roles
            .AsNoTracking()
            .Where(p => p.Id != @params.Id);
        @params.Id = null!;
        BuildQuery(@params);
        var count = await query.CountAsync();
        
        return count > 0;
    }
}