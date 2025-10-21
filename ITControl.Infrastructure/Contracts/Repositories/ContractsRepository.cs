using ITControl.Domain.Contracts.Entities;
using ITControl.Domain.Contracts.Interfaces;
using ITControl.Domain.Shared.Params;
using ITControl.Infrastructure.Contexts;
using ITControl.Infrastructure.Shared.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Contracts.Repositories;

public class ContractsRepository(ApplicationDbContext context) : 
    BaseRepository, IContractsRepository
{
    private new IQueryable<Contract> query = null!;

    public async Task<Contract?> FindOneAsync(FindOneRepositoryParams @params)
    {
        var (id, includes) = @params;
        query = context.Contracts.AsQueryable();
        ApplyIncludes(includes);
        return await query.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Contract>> FindManyAsync(
        FindManyRepositoryParams findManyParams,
        OrderByRepositoryParams? orderByParams = null,
        PaginationParams? paginationParams = null)
    {
        query = context.Contracts.AsNoTracking();
        BuildQuery(findManyParams);
        BuildOrderBy(orderByParams);
        ApplyPagination(paginationParams);
        return await query.ToListAsync();
    }

    public async Task CreateAsync(Contract contract)
    {
        await context.Contracts.AddAsync(contract);
    }

    public void Update(Contract contract)
    {
        context.Contracts.Update(contract);
    }

    public void Delete(Contract contract)
    {
        context.Contracts.Remove(contract);
    }

    public async Task<int> CountAsync(FindManyRepositoryParams @params)
    {
        query = context.Contracts.AsNoTracking();
        BuildQuery(@params);
        
        return await query.CountAsync();
    }

    public async Task<bool> ExistsAsync(FindManyRepositoryParams @params)
    {
        var count = await CountAsync(@params);
        
        return count > 0;
    }
}