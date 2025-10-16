using ITControl.Domain.Notifications.Entities;
using ITControl.Domain.Notifications.Params;
using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Notifications.Interfaces;

public interface INotificationsRepository
{
    Task<Notification?> FindOneAsync(FindOneNotificationsRepositoryParams @params);
    Task<IEnumerable<Notification>> FindManyAsync(
        FindManyNotificationsRepositoryParams findManyParams,
        OrderByNotificationsRepositoryParams? orderByParams = null,
        PaginationParams? paginationParams = null);
    Task CreateAsync(Notification notification);
    void Update(Notification notification);
    Task<int> CountAsync(CountNotificationsRepositoryParams @params);
}
