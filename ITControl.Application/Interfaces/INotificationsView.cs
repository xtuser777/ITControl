using ITControl.Communication.Notifications.Responses;
using ITControl.Domain.Entities;

namespace ITControl.Application.Interfaces;

public interface INotificationsView
{
    FindOneNotificationsResponse? FindOne(Notification? notification);
    IEnumerable<FindManyNotificationsResponse> FindMany(IEnumerable<Notification>? notifications);
    CountUnreadNotificationsResponse CountUnread(int count);
}
