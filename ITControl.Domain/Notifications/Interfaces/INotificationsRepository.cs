using ITControl.Domain.Notifications.Entities;
using ITControl.Domain.Shared.Interfaces;

namespace ITControl.Domain.Notifications.Interfaces;

public interface INotificationsRepository : IRepository<Notification>
{
    void DeleteMany(IEnumerable<Notification> notifications);
}
