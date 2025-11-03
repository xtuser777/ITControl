using ITControl.Application.Shared.Params;
using ITControl.Domain.Notifications.Entities;
using ITControl.Domain.Shared.Entities;

namespace ITControl.Application.Notifications.Interfaces;

public interface INotificationsService
{
    Task<Notification> FindOneAsync(
        FindOneServiceParams parameters);
    Task<IEnumerable<Notification>> FindManyAsync(
        FindManyServiceParams parameters);
    Task<PaginationModel?> FindManyPaginationAsync(
        FindManyPaginationServiceParams parameters);
    Task<int> CountUnreadAsync(Guid userId);
    Task UpdateAsync(
        UpdateServiceParams parameters);
}
