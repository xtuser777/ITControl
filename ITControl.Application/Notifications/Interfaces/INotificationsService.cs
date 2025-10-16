using ITControl.Communication.Notifications.Requests;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Notifications.Entities;

namespace ITControl.Application.Notifications.Interfaces;

public interface INotificationsService
{
    Task<Notification> FindOneAsync(FindOneNotificationsRequest request);
    Task<IEnumerable<Notification>> FindManyAsync(
        FindManyNotificationsRequest request,
        OrderByNotificationsRequest orderByNotificationsRequest);
    Task<PaginationResponse?> FindManyPaginationAsync(FindManyNotificationsRequest request);
    Task<int> CountUnreadAsync(Guid userId);
    Task UpdateAsync(Guid id, UpdateNotificationsRequest request);
}
