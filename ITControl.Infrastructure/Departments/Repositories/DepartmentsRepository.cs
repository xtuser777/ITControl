using ITControl.Domain.Departments.Entities;
using ITControl.Domain.Departments.Interfaces;
using ITControl.Domain.Departments.Params;
using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Shared.Params;
using ITControl.Infrastructure.Contexts;
using ITControl.Infrastructure.Shared.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Departments.Repositories;

public class DepartmentsRepository(ApplicationDbContext context) : 
    BaseRepository, IDepartmentsRepository
{
    public async Task<Entity?> FindOneAsync(
        IFindOneRepositoryParams @params)
    {
        return await context.Departments.FindAsync(
            ((FindOneDepartmentsRepositoryParams)@params).Id);
    }

    public async Task<IEnumerable<Entity>> FindManyAsync(
        IFindManyRepositoryParams findManyParams,
        IOrderByRepositoryParams? orderByParams,
        PaginationParams? paginationParams)
    {
        query = context.Departments.AsNoTracking();
        BuildQuery((FindManyDepartmentsRepositoryParams)findManyParams);
        BuildOrderBy((OrderByDepartmentsRepositoryParams?)orderByParams);
        ApplyPagination(paginationParams);
        
        return await query.ToListAsync();
    }

    public async Task CreateAsync(Entity entity)
    {
        await context.Departments.AddAsync((Department)entity);
    }

    public void Update(Entity entity)
    {
        context.Departments.Update((Department)entity);
    }

    public void Delete(Entity entity)
    {
        context.Departments.Remove((Department)entity);
    }

    public async Task<int> CountAsync(ICountRepositoryParams @params)
    {
        query = context.Departments.AsNoTracking();
        BuildQuery((CountDepartmentsRepositoryParams)@params);
        
        return await query.CountAsync();
    }

    public async Task<bool> ExistsAsync(IExistsRepositoryParams @params)
    {
        var count = await CountAsync((ExistsDepartmentsRepositoryParams)@params);
        
        return count > 0;
    }

    public async Task<bool> ExclusiveAsync(IExclusiveRepositoryParams @params)
    {
        query = context.Departments.AsNoTracking();
        query = query.Where(x => 
            x.Id != ((ExclusiveDepartmentsRepositoryParams)@params).ExcludeId);
        BuildQuery((ExclusiveDepartmentsRepositoryParams)@params);
        var count = await query.CountAsync();
        
        return count > 0;
    }
}