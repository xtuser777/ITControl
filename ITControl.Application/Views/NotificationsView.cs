using ITControl.Application.Interfaces;
using ITControl.Application.Translators;
using ITControl.Communication.Notifications.Responses;
using ITControl.Domain.Entities;

namespace ITControl.Application.Views;

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
}
