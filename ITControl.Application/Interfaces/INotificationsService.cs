using ITControl.Communication.Notifications.Requests;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Entities;

namespace ITControl.Application.Interfaces;

public interface INotificationsService
{
    Task<IEnumerable<Notification>> FindMany(FindManyNotificationsRequest request);
    Task<PaginationResponse?> FindManyPagination(FindManyNotificationsRequest request);
    Task Update(Guid id, UpdateNotificationsRequest request);
}
