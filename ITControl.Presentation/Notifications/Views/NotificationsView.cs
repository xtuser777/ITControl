using ITControl.Domain.Notifications.Entities;
using ITControl.Domain.Shared.Extensions;
using ITControl.Presentation.Notifications.Interfaces;
using ITControl.Presentation.Notifications.Responses;
using ITControl.Presentation.Shared.Responses;

namespace ITControl.Presentation.Notifications.Views;

public class NotificationsView : INotificationsView
{
    public IEnumerable<FindManyNotificationsResponse> FindMany(IEnumerable<Notification>? notifications)
    {
        if (notifications is null)
        {
            return [];
        }

        return notifications.Select(n => new FindManyNotificationsResponse
        {
            Id = n.Id,
            Title = n.Title,
            Message = n.Message,
            Type = new TranslatableField
            {
                Value = n.Type.ToString(),
                DisplayValue = n.Type.GetDisplayValue()
            },
            Reference = new TranslatableField
            {
                Value = n.Reference.ToString(),
                DisplayValue = n.Reference.GetDisplayValue()
            },
            IsRead = n.IsRead,
            UserId = n.UserId,
            CallId = n.CallId,
            AppointmentId = n.AppointmentId,
            TreatmentId = n.TreatmentId,
            CreatedAt = n.CreatedAt,
            ReadAt = n.UpdatedAt
        });
    }

    public FindOneNotificationsResponse? FindOne(Notification? notification)
    {
        if (notification is null)
        {
            return null;
        }

        return new FindOneNotificationsResponse
        {
            Id = notification.Id,
            Title = notification.Title,
            Message = notification.Message,
            Type = new TranslatableField
            {
                Value = notification.Type.ToString(),
                DisplayValue = notification.Type.GetDisplayValue()
            },
            Reference = new TranslatableField
            {
                Value = notification.Reference.ToString(),
                DisplayValue = notification.Reference.GetDisplayValue()
            },
            IsRead = notification.IsRead,
            UserId = notification.UserId,
            CallId = notification.CallId,
            AppointmentId = notification.AppointmentId,
            TreatmentId = notification.TreatmentId,
            CreatedAt = notification.CreatedAt,
            ReadAt = notification.UpdatedAt
        };
    }

    public CountUnreadNotificationsResponse CountUnread(int count)
    {
        return new CountUnreadNotificationsResponse
        {
            Count = count
        };
    }
}
