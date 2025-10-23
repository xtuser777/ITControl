using ITControl.Domain.Roles.Entities;
using ITControl.Domain.Roles.Interfaces;
using ITControl.Domain.Shared.Params2;
using ITControl.Infrastructure.Contexts;
using ITControl.Infrastructure.Shared.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Roles.Repositories;

public class RolesRepository(ApplicationDbContext context)
    : BaseRepository, IRolesRepository
{
    public async Task<Role?> FindOneAsync(
        FindOneRepositoryParams parameters)
    {
        var (id, includes) = parameters;
        query = context.Roles.AsQueryable();
        ApplyIncludes(includes);

        return (Role?)await query
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Role>> FindManyAsync(
        FindManyRepositoryParams parameters)
    {
        query = context.Roles.AsNoTracking();
        BuildQuery(parameters.FindMany);
        BuildOrderBy(parameters.OrderBy);
        ApplyPagination(parameters.Pagination);
        return (await query.ToListAsync()).Cast<Role>();
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

    public async Task<int> CountAsync(
        FindManyParams parameters)
    {
        query = context.Roles.AsNoTracking();
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
        query = context.Roles.AsNoTracking();
        BuildQuery(parameters);
        var count = await query.CountAsync();
        return count > 0;
    }
}