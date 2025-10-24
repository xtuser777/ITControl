using ITControl.Domain.Contracts.Entities;
using ITControl.Domain.Contracts.Interfaces;
using ITControl.Domain.Shared.Params2;
using ITControl.Infrastructure.Contexts;
using ITControl.Infrastructure.Shared.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Contracts.Repositories;

public class ContractsRepository(ApplicationDbContext context) : 
    BaseRepository, IContractsRepository
{
    private new IQueryable<Contract> query = null!;

    public async Task<Contract?> FindOneAsync(
        FindOneRepositoryParams parameters)
    {
        var (id, includes) = parameters;
        query = context.Contracts.AsQueryable();
        ApplyIncludes(includes);
        return await query.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Contract>> FindManyAsync(
        FindManyRepositoryParams parameters)
    {
        query = context.Contracts.AsNoTracking();
        BuildQuery(parameters.FindMany);
        BuildOrderBy(parameters.OrderBy);
        ApplyPagination(parameters.Pagination);
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

    public async Task<int> CountAsync(FindManyParams parameters)
    {
        query = context.Contracts.AsNoTracking();
        BuildQuery(parameters);
        return await query.CountAsync();
    }

    public async Task<bool> ExistsAsync(FindManyParams parameters)
    {
        var count = await CountAsync(parameters);
        return count > 0;
    }
}