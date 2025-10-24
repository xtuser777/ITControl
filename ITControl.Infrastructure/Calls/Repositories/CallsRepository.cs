using ITControl.Domain.Calls.Entities;
using ITControl.Domain.Calls.Interfaces;
using ITControl.Domain.Shared.Params2;
using ITControl.Infrastructure.Contexts;
using ITControl.Infrastructure.Shared.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Calls.Repositories;

public class CallsRepository(
    ApplicationDbContext context) : BaseRepository, ICallsRepository
{
    public async Task<Call?> FindOneAsync(FindOneRepositoryParams @params)
    {
        query = context.Calls.AsQueryable();
        query = query.Include(c => ((Call)c).CallStatus);
        ApplyIncludes(@params.Includes);
        return (Call?)await query.FirstOrDefaultAsync(c => c.Id == @params.Id);
    }

    public async Task<IEnumerable<Call>> FindManyAsync(
        FindManyRepositoryParams parameters)
    {
        query = context.Calls
            .Include(c => c.CallStatus)
            .Include(c => c.User)
            .AsNoTracking();
        BuildQuery(parameters.FindMany);
        BuildOrderBy(parameters.OrderBy);
        ApplyPagination(parameters.Pagination);
        return (await query.ToListAsync()).Cast<Call>();
    }

    public async Task CreateAsync(Call call)
    {
        await context.Calls.AddAsync(call);
    }

    public void Update(Call call)
    {
        context.Calls.Update(call);
    }

    public void Delete(Call call)
    {
        context.Calls.Remove(call);
    }

    public Task<int> CountAsync(FindManyParams parameters)
    {
        query = context.Calls.AsNoTracking();
        BuildQuery(parameters);
        return query.CountAsync();
    }

    public async Task<bool> ExistsAsync(FindManyParams parameters)
    {
        var count = await CountAsync(parameters);
        return count > 0;
    }
}
