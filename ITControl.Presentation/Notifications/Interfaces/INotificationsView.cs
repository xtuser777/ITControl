using ITControl.Domain.Notifications.Entities;
using ITControl.Presentation.Notifications.Responses;

namespace ITControl.Presentation.Notifications.Interfaces;

public interface INotificationsView
{
    FindOneNotificationsResponse? FindOne(Notification? notification);
    IEnumerable<FindManyNotificationsResponse> FindMany(IEnumerable<Notification>? notifications);
    CountUnreadNotificationsResponse CountUnread(int count);
}
