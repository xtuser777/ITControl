using ITControl.Domain.Notifications.Props;

namespace ITControl.Domain.Notifications.Entities;

public sealed class Notification : NotificationProps
{
    public Notification()
    {
        Id = Guid.NewGuid();
        IsRead = false;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public Notification(NotificationProps @params)
    {
        Assign(@params);
    }

    public void MarkAsRead()
    {
        IsRead = true;
        UpdatedAt = DateTime.Now;
    }

    public void Update(NotificationProps @params)
    {
        AssignUpdate(@params);
    }
}
