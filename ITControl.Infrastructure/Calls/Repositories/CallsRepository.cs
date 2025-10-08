using ITControl.Domain.Calls.Entities;
using ITControl.Domain.Calls.Interfaces;
using ITControl.Domain.Calls.Params;
using ITControl.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Calls.Repositories;

public class CallsRepository(
    ApplicationDbContext context) : ICallsRepository
{
    public Task<Call?> FindOneAsync(FindOneCallsRepositoryParams @params)
    {
        var query = context.Calls.AsQueryable();
        query = query.Include(c => c.CallStatus);
        if (@params.IncludeUser == true)
        {
            query = query
                .Include(c => c.User).ThenInclude(u => u!.Position)
                .Include(c => c.User).ThenInclude(u => u!.Unit)
                .Include(c => c.User).ThenInclude(u => u!.Department)
                .Include(c => c.User).ThenInclude(u => u!.Division);
        }
        if (@params.IncludeEquipment == true)
        {
            query = query.Include(c => c.Equipment);
        }
        if (@params.IncludeSystem == true)
        {
            query = query.Include(c => c.System);
        }

        return query.FirstOrDefaultAsync(c => c.Id == @params.Id);
    }

    public async Task<IEnumerable<Call>> FindManyAsync(FindManyCallsRepositoryParams @params)
    {
        var (page, size) = @params;
        var query = context.Calls
            .Include(c => c.CallStatus)
            .Include(c => c.User)
            .AsNoTracking();
        query = BuildQuery(new BuildQueryCallsRepositoryParams()
        {
            Query = query,
            Params = @params
        });
        query = ApplySorting(new BuildOrderByCallsRepositoryParams()
        {
            Query = query,
            Params = @params,
        });
        if (page.HasValue && size.HasValue)
        {
            var skip = (page.Value - 1) * size.Value;
            query = query.Skip(skip).Take(size.Value);
        }

        return await query.ToListAsync();
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

    public Task<int> CountAsync(CountCallsRepositoryParams @params)
    {
        var query = context.Calls.AsNoTracking();
        query = BuildQuery(new BuildQueryCallsRepositoryParams()
        {
            Query = query,
            Params = @params
        });

        return query.CountAsync();
    }

    public async Task<bool> ExistsAsync(ExistsCallsRepositoryParams @params)
    {
        var count = await CountAsync(@params);

        return count > 0;
    }

    private static IQueryable<Call> BuildQuery(BuildQueryCallsRepositoryParams @buildParams)
    {
        var (query, @params) = @buildParams;
        if (@params.Id.HasValue)
        {
            query = query.Where(c => c.Id == @params.Id.Value);
        }
        if (!string.IsNullOrEmpty(@params.Title))
        {
            query = query.Where(c => c.Title.Contains(@params.Title));
        }
        if (!string.IsNullOrEmpty(@params.Description))
        {
            query = query.Where(c => c.Description.Contains(@params.Description));
        }
        if (@params.Reason.HasValue)
        {
            query = query.Where(c => c.Reason == @params.Reason.Value);
        }
        if (@params.Status.HasValue)
        {
            query = query.Where(c => c.CallStatus!.Status == @params.Status.Value);
        }
        if (@params.UserId.HasValue)
        {
            query = query.Where(c => c.UserId == @params.UserId.Value);
        }

        return query;
    }

    private static IQueryable<Call> ApplySorting(BuildOrderByCallsRepositoryParams @orderByParams)
    {
        var (query, @params) = @orderByParams;
        if (!string.IsNullOrEmpty(@params.OrderByTitle))
        {
            query = @params.OrderByTitle.Equals("a", StringComparison.CurrentCultureIgnoreCase) ? 
                query.OrderBy(c => c.Title) : 
                query.OrderByDescending(c => c.Title);
        }
        if (!string.IsNullOrEmpty(@params.OrderByDescription))
        {
            query = @params.OrderByDescription.Equals("a", StringComparison.CurrentCultureIgnoreCase) ? 
                query.OrderBy(c => c.Description) : 
                query.OrderByDescending(c => c.Description);
        }
        if (!string.IsNullOrEmpty(@params.OrderByReason))
        {
            query = @params.OrderByReason.Equals("a", StringComparison.CurrentCultureIgnoreCase) ? 
                query.OrderBy(c => c.Reason) : 
                query.OrderByDescending(c => c.Reason);
        }
        if (!string.IsNullOrEmpty(@params.OrderByStatus)) 
        {
            query = @params.OrderByStatus.Equals("a", StringComparison.CurrentCultureIgnoreCase) ? 
                query.OrderBy(c => c.CallStatus!.Status) : 
                query.OrderByDescending(c => c.CallStatus!.Status);
        }
        if (!string.IsNullOrEmpty(@params.OrderByUser))
        {
            query = @params.OrderByUser.Equals("a", StringComparison.CurrentCultureIgnoreCase) ? 
                query.OrderBy(c => c.User!.Name) : 
                query.OrderByDescending(c => c.User!.Name);
        }
        return query;
    }
}
