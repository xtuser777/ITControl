using ITControl.Domain.Entities;
using ITControl.Domain.Enums;
using ITControl.Domain.Interfaces;
using ITControl.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Repositories;

public class NotificationsRepository(
    ApplicationDbContext context) : INotificationsRepository
{
    public async Task<Notification?> FindOneAsync(Guid id, bool? includeUser = null)
    {
        var query = context.Notifications.AsQueryable();
        if (includeUser == true)
        {
            query = query.Include(n => n.User);
        }

        return await query.FirstOrDefaultAsync(n => n.Id == id);
    }

    public async Task<IEnumerable<Notification>> FindManyAsync(
        string? title = null, 
        string? message = null, 
        NotificationType? type = null, 
        NotificationReference? reference = null, 
        bool? isRead = null, 
        Guid? userId = null, 
        string? orderByTitle = null, 
        string? orderByMessage = null, 
        string? orderByType = null, 
        string? orderByReference = null, 
        string? orderByIsRead = null, 
        string? orderByUser = null, 
        int? page = null, 
        int? size = null)
    {
        var query = context.Notifications.AsNoTracking();
        query = BuildQuery(query, title, message, type, reference, isRead, userId);
        query = ApplySorting(query, orderByTitle, orderByMessage, orderByType, orderByReference, orderByIsRead, orderByUser);
        if (page.HasValue && size.HasValue)
        {
            var skip = (page.Value - 1) * size.Value;
            query = query.Skip(skip).Take(size.Value);
        }

        return await query.ToListAsync();
    }

    public async Task CreateAsync(Notification notification)
    {
        await context.Notifications.AddAsync(notification);
    }

    public void Update(Notification notification)
    {
        context.Notifications.Update(notification);
    }

    public Task<int> CountAsync(
        string? title = null, 
        string? message = null, 
        NotificationType? type = null, 
        NotificationReference? reference = null, 
        bool? isRead = null, 
        Guid? userId = null)
    {
        var query = context.Notifications.AsNoTracking();
        query = BuildQuery(query, title, message, type, reference, isRead, userId);

        return query.CountAsync();
    }

    private IQueryable<Notification> BuildQuery(
        IQueryable<Notification> query,
        string? title = null, 
        string? message = null, 
        NotificationType? type = null, 
        NotificationReference? reference = null, 
        bool? isRead = null, 
        Guid? userId = null)
    {
        if (!string.IsNullOrWhiteSpace(title))
        {
            query = query.Where(n => n.Title.Contains(title));
        }
        if (!string.IsNullOrWhiteSpace(message))
        {
            query = query.Where(n => n.Message.Contains(message));
        }
        if (type.HasValue)
        {
            query = query.Where(n => n.Type == type.Value);
        }
        if (reference.HasValue)
        {
            query = query.Where(n => n.Reference == reference.Value);
        }
        if (isRead.HasValue)
        {
            query = query.Where(n => n.IsRead == isRead.Value);
        }
        if (userId.HasValue)
        {
            query = query.Where(n => n.UserId == userId.Value);
        }
        return query;
    }

    private IQueryable<Notification> ApplySorting(
        IQueryable<Notification> query,
        string? orderByTitle = null, 
        string? orderByMessage = null, 
        string? orderByType = null, 
        string? orderByReference = null, 
        string? orderByIsRead = null, 
        string? orderByUser = null)
    {
        if (!string.IsNullOrWhiteSpace(orderByTitle))
        {
            query = orderByTitle.ToLower() == "d" 
                ? query.OrderByDescending(n => n.Title) 
                : query.OrderBy(n => n.Title);
        }
        if (!string.IsNullOrWhiteSpace(orderByMessage))
        {
            query = orderByMessage.ToLower() == "d" 
                ? query.OrderByDescending(n => n.Message) 
                : query.OrderBy(n => n.Message);
        }
        if (!string.IsNullOrWhiteSpace(orderByType))
        {
            query = orderByType.ToLower() == "d" 
                ? query.OrderByDescending(n => n.Type) 
                : query.OrderBy(n => n.Type);
        }
        if (!string.IsNullOrWhiteSpace(orderByReference))
        {
            query = orderByReference.ToLower() == "d" 
                ? query.OrderByDescending(n => n.Reference) 
                : query.OrderBy(n => n.Reference);
        }
        if (!string.IsNullOrWhiteSpace(orderByIsRead))
        {
            query = orderByIsRead.ToLower() == "d"
                ? query.OrderByDescending(n => n.IsRead) 
                : query.OrderBy(n => n.IsRead);
        }
        if (!string.IsNullOrWhiteSpace(orderByUser))
        {
            query = orderByUser.ToLower() == "d" 
                ? query.OrderByDescending(n => n.UserId) 
                : query.OrderBy(n => n.UserId);
        }
        return query;
    }
}
