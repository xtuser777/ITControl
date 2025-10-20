using ITControl.Domain.Departments.Entities;
using ITControl.Domain.Departments.Interfaces;
using ITControl.Domain.Departments.Params;
using ITControl.Domain.Shared.Params;
using ITControl.Infrastructure.Contexts;
using ITControl.Infrastructure.Shared.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Departments.Repositories;

public class DepartmentsRepository(ApplicationDbContext context) : 
    BaseRepository, IDepartmentsRepository
{
    public async Task<Department?> FindOneAsync(
        FindOneRepositoryParams @params)
    {
        return await context.Departments.FindAsync(@params.Id);
    }

    public async Task<IEnumerable<Department>> FindManyAsync(
        FindManyRepositoryParams findManyParams,
        OrderByRepositoryParams? orderByParams,
        PaginationParams? paginationParams)
    {
        query = context.Departments.AsNoTracking();
        BuildQuery((FindManyDepartmentsRepositoryParams)findManyParams);
        BuildOrderBy((OrderByDepartmentsRepositoryParams?)orderByParams);
        ApplyPagination(paginationParams);
        
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

    public async Task<int> CountAsync(FindManyRepositoryParams @params)
    {
        query = context.Departments.AsNoTracking();
        BuildQuery((CountDepartmentsRepositoryParams)@params);
        
        return await query.CountAsync();
    }

    public async Task<bool> ExistsAsync(FindManyRepositoryParams @params)
    {
        var count = await CountAsync((ExistsDepartmentsRepositoryParams)@params);
        
        return count > 0;
    }

    public async Task<bool> ExclusiveAsync(FindManyRepositoryParams @params)
    {
        query = context.Departments.AsNoTracking();
        BuildQuery((ExclusiveDepartmentsRepositoryParams)@params);
        var count = await query.CountAsync();
        
        return count > 0;
    }
}