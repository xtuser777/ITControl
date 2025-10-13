using ITControl.Domain.Contracts.Entities;
using ITControl.Domain.Contracts.Interfaces;
using ITControl.Domain.Contracts.Params;
using ITControl.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Contracts.Repositories;

public class ContractsRepository(ApplicationDbContext context) : IContractsRepository
{
    private IQueryable<Contract> query = null!;

    public async Task<Contract?> FindOneAsync(FindOneContractsRepositoryParams @params)
    {
        var (id, includeContractsContacts) = @params;
        query = context.Contracts.AsQueryable();
        if (includeContractsContacts is true) 
            query = query.Include(x => x.ContractContacts);
        
        return await query.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Contract>> FindManyAsync(
        FindManyContractsRepositoryParams findManyParams,
        OrderByContractsRepositoryParams orderByParams)
    {
        var (page, size) = findManyParams;
        query = context.Contracts.AsNoTracking();
        BuildQuery(findManyParams);
        BuildOrderBy(orderByParams);
        if (page != null && size != null)
            query = query.Skip((page.Value - 1) * size.Value).Take(size.Value);

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

    public async Task<int> CountAsync(CountContractsRepositoryParams @params)
    {
        query = context.Contracts.AsNoTracking();
        BuildQuery(@params);
        
        return await query.CountAsync();
    }

    public async Task<bool> ExistsAsync(ExistsContractsRepositoryParams @params)
    {
        var count = await CountAsync(@params);
        
        return count > 0;
    }

    private void BuildQuery(CountContractsRepositoryParams @params)
    {
        if (@params.Id != null) 
            query = query.Where(x => x.Id == @params.Id);
        if (@params.ObjectName != null) 
            query = query.Where(x => x.ObjectName.Contains(@params.ObjectName));
        if (@params.StartedAt != null) 
            query = query.Where(x => x.StartedAt.Equals(@params.StartedAt));
        if (@params.EndedAt != null) 
            query = query.Where(x => x.EndedAt.Equals(@params.EndedAt));
    }

    private void BuildOrderBy(OrderByContractsRepositoryParams @params)
    {
        query = @params.ObjectName switch
        {
            "a" => query.OrderBy(p => p.ObjectName),
            "d" => query.OrderByDescending(p => p.ObjectName),
            _ => query
        };
        query = @params.StartedAt switch
        {
            "a" => query.OrderBy(p => p.StartedAt),
            "d" => query.OrderByDescending(p => p.StartedAt),
            _ => query
        };
        query = @params.EndedAt switch
        {
            "a" => query.OrderBy(p => p.EndedAt),
            "d" => query.OrderByDescending(p => p.EndedAt),
            _ => query
        };
    }
}