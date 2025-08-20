using ITControl.Domain.Entities;
using ITControl.Domain.Enums;
using ITControl.Domain.Interfaces;
using ITControl.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Repositories;

public class CallsRepository(
    ApplicationDbContext context) : ICallsRepository
{
    public Task<Call?> FindOneAsync(
        Guid id,
        bool? includeUser = null,
        bool? includeLocation = null,
        bool? includeEquipment = null,
        bool? includeSystem = null)
    {
        var query = context.Calls.AsQueryable();
        query = query.Include(c => c.CallStatus);
        if (includeUser == true)
        {
            query = query.Include(c => c.User);
        }
        if (includeLocation == true)
        {
            query = query.Include(c => c.Location);
        }
        if (includeEquipment == true)
        {
            query = query.Include(c => c.Equipment);
        }
        if (includeSystem == true)
        {
            query = query.Include(c => c.System);
        }

        return query.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IEnumerable<Call>> FindManyAsync(
        string? title = null, 
        string? description = null,
        CallReason? reason = null,
        Domain.Enums.CallStatus? status = null,
        Guid? userId = null, 
        Guid? locationId = null, 
        string? orderByTitle = null, 
        string? orderByDescription = null,
        string? orderByReason = null,
        string? orderByStatus = null,
        string? orderByUser = null, 
        string? orderByLocation = null, 
        int? page = null, int? size = null)
    {
        var query = context.Calls
            .Include(c => c.CallStatus)
            .Include(c => c.User)
            .Include(c => c.Location)
            .AsQueryable();
        query = BuildQuery(
            query, null, title, description, reason, status, userId, locationId);
        query = ApplySorting(
            query, orderByTitle, orderByDescription, orderByStatus, orderByUser, orderByLocation);
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

    public Task<int> CountAsync(
        Guid? id = null, 
        string? title = null, 
        string? description = null,
        CallReason? reason = null,
        Domain.Enums.CallStatus? status = null,
        Guid? userId = null, 
        Guid? locationId = null)
    {
        var query = context.Calls.AsNoTracking();
        query = BuildQuery(query, id, title, description, reason, status, userId, locationId);

        return query.CountAsync();
    }

    public async Task<bool> ExistsAsync(
        Guid? id = null, 
        string? title = null, 
        string? description = null,
        CallReason? reason = null,
        Domain.Enums.CallStatus? status = null,
        Guid? userId = null, 
        Guid? locationId = null)
    {
        var count = await CountAsync(id, title, description, reason, status, userId, locationId);

        return count > 0;
    }

    private IQueryable<Call> BuildQuery(
        IQueryable<Call> query,
        Guid? id = null,
        string? title = null,
        string? description = null,
        CallReason? reason = null,
        Domain.Enums.CallStatus? status = null,
        Guid? userId = null,
        Guid? locationId = null)
    {
        if (id.HasValue)
        {
            query = query.Where(c => c.Id == id.Value);
        }
        if (!string.IsNullOrEmpty(title))
        {
            query = query.Where(c => c.Title.Contains(title));
        }
        if (!string.IsNullOrEmpty(description))
        {
            query = query.Where(c => c.Description.Contains(description));
        }
        if (reason.HasValue)
        {
            query = query.Where(c => c.Reason == reason.Value);
        }
        if (status.HasValue)
        {
            query = query.Where(c => c.CallStatus!.Status == status.Value);
        }
        if (userId.HasValue)
        {
            query = query.Where(c => c.UserId == userId.Value);
        }
        if (locationId.HasValue)
        {
            query = query.Where(c => c.LocationId == locationId.Value);
        }

        return query;
    }

    private IQueryable<Call> ApplySorting(
        IQueryable<Call> query,
        string? orderByTitle = null,
        string? orderByDescription = null,
        string? orderByReason = null,
        string? orderByStatus = null,
        string? orderByUser = null,
        string? orderByLocation = null)
    {
        if (!string.IsNullOrEmpty(orderByTitle))
        {
            query = orderByTitle.Equals("a", StringComparison.CurrentCultureIgnoreCase) ? 
                query.OrderBy(c => c.Title) : 
                query.OrderByDescending(c => c.Title);
        }
        if (!string.IsNullOrEmpty(orderByDescription))
        {
            query = orderByDescription.Equals("a", StringComparison.CurrentCultureIgnoreCase) ? 
                query.OrderBy(c => c.Description) : 
                query.OrderByDescending(c => c.Description);
        }
        if (!string.IsNullOrEmpty(orderByReason))
        {
            query = orderByReason.Equals("a", StringComparison.CurrentCultureIgnoreCase) ? 
                query.OrderBy(c => c.Reason) : 
                query.OrderByDescending(c => c.Reason);
        }
        if (!string.IsNullOrEmpty(orderByStatus)) 
        {
            query = orderByStatus.Equals("a", StringComparison.CurrentCultureIgnoreCase) ? 
                query.OrderBy(c => c.CallStatus!.Status) : 
                query.OrderByDescending(c => c.CallStatus!.Status);
        }
        if (!string.IsNullOrEmpty(orderByUser))
        {
            query = orderByUser.Equals("a", StringComparison.CurrentCultureIgnoreCase) ? 
                query.OrderBy(c => c.User!.Name) : 
                query.OrderByDescending(c => c.User!.Name);
        }
        if (!string.IsNullOrEmpty(orderByLocation))
        {
            query = orderByLocation.Equals("a", StringComparison.CurrentCultureIgnoreCase) ? 
                query.OrderBy(c => c.Location!.Description) : 
                query.OrderByDescending(c => c.Location!.Description);
        }
        return query;
    }
}
