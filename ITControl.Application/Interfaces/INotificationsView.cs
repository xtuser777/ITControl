using ITControl.Communication.Notifications.Responses;
using ITControl.Domain.Entities;

namespace ITControl.Application.Interfaces;

public interface INotificationsView
{
    IEnumerable<FindManyNotificationsResponse> FindMany(IEnumerable<Notification>? notifications);
}
