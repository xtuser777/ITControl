using ITControl.Application.Notifications.Params;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Notifications.Entities;

namespace ITControl.Application.Notifications.Interfaces;

public interface INotificationsService
{
    Task<Notification> FindOneAsync(
        FindOneNotificationsServiceParams @params);
    Task<IEnumerable<Notification>> FindManyAsync(
        FindManyNotificationsServiceParams @params);
    Task<PaginationResponse?> FindManyPaginationAsync(
        FindManyPaginationNotificationsServiceParams @params);
    Task<int> CountUnreadAsync(Guid userId);
    Task UpdateAsync(UpdateNotificationsServiceParams @params);
}
