using ITControl.Communication.Notifications.Responses;
using ITControl.Domain.Notifications.Entities;

namespace ITControl.Application.Notifications.Interfaces;

public interface INotificationsView
{
    FindOneNotificationsResponse? FindOne(Notification? notification);
    IEnumerable<FindManyNotificationsResponse> FindMany(IEnumerable<Notification>? notifications);
    CountUnreadNotificationsResponse CountUnread(int count);
}
