using ITControl.Application.Shared.Params;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Notifications.Entities;

namespace ITControl.Application.Notifications.Interfaces;

public interface INotificationsService
{
    Task<Notification> FindOneAsync(
        FindOneServiceParams parameters);
    Task<IEnumerable<Notification>> FindManyAsync(
        FindManyServiceParams parameters);
    Task<PaginationResponse?> FindManyPaginationAsync(
        FindManyPaginationServiceParams parameters);
    Task<int> CountUnreadAsync(Guid userId);
    Task UpdateAsync(
        UpdateServiceParams parameters);
}
