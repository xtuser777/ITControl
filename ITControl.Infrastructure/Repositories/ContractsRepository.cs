using ITControl.Domain.Entities;
using ITControl.Domain.Interfaces;
using ITControl.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Repositories;

public class ContractsRepository(ApplicationDbContext context) : IContractsRepository
{
    public async Task<Contract?> FindOneAsync(Guid id, bool? includeContractsContacts = null)
    {
        var query = context.Contracts.AsQueryable();
        if (includeContractsContacts != null) 
            query = query.Include(x => x.ContractContacts);
        
        return await query.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Contract>> FindManyAsync(
        string? objectValue = null, 
        DateOnly? startedAt = null, 
        DateOnly? endedAt = null, 
        string? orderByObject = null,
        string? orderByStartedAt = null,
        string? orderByEndedAt = null,
        int? page = null,
        int? size = null)
    {
        var query = context.Contracts.AsNoTracking();
        query = BuildQuery(
            query: query,
            objectValue: objectValue,
            startedAt: startedAt,
            endedAt: endedAt);
        query = BuildOrderBy(query, orderByObject, orderByStartedAt, orderByEndedAt);
        
        return await query.ToListAsync();
    }

    public async Task CreateAsync(Contract contract)
    {
        await context.Contracts.AddAsync(contract);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Contract contract)
    {
        context.Contracts.Update(contract);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Contract contract)
    {
        context.Contracts.Remove(contract);
        await context.SaveChangesAsync();
    }

    public async Task<int> CountAsync(
        Guid? id = null, 
        string? objectValue = null, 
        DateOnly? startedAt = null, 
        DateOnly? endedAt = null)
    {
        var query = context.Contracts.AsNoTracking();
        query = BuildQuery(
            query: query,
            id: id,
            objectValue: objectValue,
            startedAt: startedAt,
            endedAt: endedAt);
        
        return await query.CountAsync();
    }

    public async Task<bool> ExistsAsync(
        Guid? id = null, 
        string? objectValue = null, 
        DateOnly? startedAt = null, 
        DateOnly? endedAt = null)
    {
        var count = await CountAsync(id, objectValue, startedAt, endedAt);
        
        return count > 0;
    }

    public async Task<bool> ExclusiveAsync(
        Guid id, 
        string? objectValue = null, 
        DateOnly? startedAt = null, 
        DateOnly? endedAt = null)
    {
        var query = context.Contracts.AsNoTracking();
        query = query.Where(x => x.Id != id);
        query = BuildQuery(
            query: query,
            objectValue: objectValue,
            startedAt: startedAt,
            endedAt: endedAt);
        var count = await query.CountAsync();
        
        return count > 0;
    }

    private IQueryable<Contract> BuildQuery(
        IQueryable<Contract> query,
        Guid? id = null,
        string? objectValue = null,
        DateOnly? startedAt = null,
        DateOnly? endedAt = null)
    {
        if (id != null) query = query.Where(x => x.Id == id);
        if (objectValue != null) query = query.Where(x => x.Object.Contains(objectValue));
        if (startedAt != null) query = query.Where(x => x.StartedAt.Equals(startedAt));
        if (endedAt != null) query = query.Where(x => x.EndedAt.Equals(endedAt));
        
        return query;
    }

    private IQueryable<Contract> BuildOrderBy(
        IQueryable<Contract> query, 
        string? orderByObject = null,
        string? orderByStartedAt = null,
        string? orderByEndedAt = null)
    {
        query = orderByObject switch
        {
            "a" => query.OrderBy(p => p.Object),
            "d" => query.OrderByDescending(p => p.Object),
            _ => query
        };
        query = orderByStartedAt switch
        {
            "a" => query.OrderBy(p => p.StartedAt),
            "d" => query.OrderByDescending(p => p.StartedAt),
            _ => query
        };
        query = orderByEndedAt switch
        {
            "a" => query.OrderBy(p => p.EndedAt),
            "d" => query.OrderByDescending(p => p.EndedAt),
            _ => query
        };
        
        return query;
    }
}