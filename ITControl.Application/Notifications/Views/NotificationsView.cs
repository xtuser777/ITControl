using ITControl.Application.Notifications.Interfaces;
using ITControl.Application.Translators;
using ITControl.Communication.Notifications.Responses;
using ITControl.Domain.Notifications.Entities;

namespace ITControl.Application.Notifications.Views;

public class NotificationsView : INotificationsView
{
    public IEnumerable<FindManyNotificationsResponse> FindMany(IEnumerable<Notification>? notifications)
    {
        if (notifications is null || !notifications.Any())
        {
            return [];
        }

        return notifications.Select(n => new FindManyNotificationsResponse
        {
            Id = n.Id,
            Title = n.Title,
            Message = n.Message,
            Type = new()
            {
                Value = n.Type.ToString(),
                DisplayValue = NotificationTypeTranslator.ToDisplayValue(n.Type)
            },
            Reference = new()
            {
                Value = n.Reference.ToString(),
                DisplayValue = NotificationReferenceTranslator.ToDisplayValue(n.Reference)
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
            Type = new()
            {
                Value = notification.Type.ToString(),
                DisplayValue = NotificationTypeTranslator.ToDisplayValue(notification.Type)
            },
            Reference = new()
            {
                Value = notification.Reference.ToString(),
                DisplayValue = NotificationReferenceTranslator.ToDisplayValue(notification.Reference)
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
