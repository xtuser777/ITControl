using ITControl.Domain.Departments.Entities;
using ITControl.Domain.Departments.Interfaces;
using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Shared.Params;
using ITControl.Infrastructure.Shared.Contexts;
using ITControl.Infrastructure.Shared.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Departments.Repositories;

public class DepartmentsRepository(ApplicationDbContext context) : 
    BaseRepository, IDepartmentsRepository
{
    public async Task<Department?> FindOneAsync(
        FindOneRepositoryParams parameters)
    {
        return await context.Departments
            .FindAsync(parameters.Id);
    }

    public async Task<IEnumerable<Department>> FindManyAsync(
        FindManyRepositoryParams parameters)
    {
        query = context.Departments.AsNoTracking();
        BuildQuery(parameters.FindManyProps);
        BuildOrderBy(parameters.OrderBy);
        ApplyPagination(parameters.Pagination);
        
        return (await query.ToListAsync()).Cast<Department>();
    }

    public async Task CreateAsync(Department entity)
    {
        await context.Departments.AddAsync(entity);
    }

    public void Update(Department entity)
    {
        context.Departments.Update(entity);
    }

    public void Delete(Department entity)
    {
        context.Departments.Remove(entity);
    }

    public async Task<int> CountAsync(
        Entity parameters)
    {
        query = context.Departments.AsNoTracking();
        BuildQuery(parameters);
        return await query.CountAsync();
    }

    public async Task<bool> ExistsAsync(
        Entity parameters)
    {
        var count = await CountAsync(parameters);
        return count > 0;
    }

    public async Task<bool> ExclusiveAsync(
        Entity parameters)
    {
        query = context.Departments.AsNoTracking();
        BuildQuery(parameters);
        var count = await query.CountAsync();
        return count > 0;
    }
}