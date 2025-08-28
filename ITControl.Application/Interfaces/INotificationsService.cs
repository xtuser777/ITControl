using ITControl.Communication.Notifications.Requests;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Entities;

namespace ITControl.Application.Interfaces;

public interface INotificationsService
{
    Task<Notification> FindOneAsync(
        Guid id,
        bool? includeUser = null,
        bool? includeCall = null,
        bool? includeAppointment = null,
        bool? includeTreatment = null);
    Task<IEnumerable<Notification>> FindManyAsync(FindManyNotificationsRequest request);
    Task<PaginationResponse?> FindManyPaginationAsync(FindManyNotificationsRequest request);
    Task UpdateAsync(Guid id, UpdateNotificationsRequest request);
}
