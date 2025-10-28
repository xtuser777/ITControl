using ITControl.Domain.Notifications.Entities;
using ITControl.Domain.Notifications.Interfaces;
using ITControl.Domain.Shared.Params;
using ITControl.Infrastructure.Contexts;
using ITControl.Infrastructure.Shared.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Notifications.Repositories;

public class NotificationsRepository(
    ApplicationDbContext context) : 
    BaseRepository, INotificationsRepository
{
    public async Task<Notification?> FindOneAsync(
        FindOneRepositoryParams parameters)
    {
        var (id, includes) = parameters;
        query = context.Notifications.AsQueryable();
        ApplyIncludes(includes);

        return (Notification?)await query
            .FirstOrDefaultAsync(n => n.Id == id);
    }

    public async Task<IEnumerable<Notification>> FindManyAsync(
        FindManyRepositoryParams parameters)
    {
        query = context.Notifications.AsNoTracking();
        BuildQuery(parameters.FindMany);
        BuildOrderBy(parameters.OrderBy);
        ApplyPagination(parameters.Pagination);
        return (await query.ToListAsync()).Cast<Notification>();
    }

    public async Task CreateAsync(Notification notification)
    {
        await context.Notifications.AddAsync(notification);
    }

    public void Update(Notification notification)
    {
        context.Notifications.Update(notification);
    }

    public Task<int> CountAsync(FindManyParams parameters)
    {
        query = context.Notifications.AsNoTracking();
        BuildQuery(parameters);
        return query.CountAsync();
    }
}
