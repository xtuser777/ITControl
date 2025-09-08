using ITControl.Application.Notifications.Interfaces;
using ITControl.Application.Notifications.Translators;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Notifications.Enums;

namespace ITControl.Application.Notifications.Views;

public class NotificationsTypesView : INotificationsTypesView
{
    public IEnumerable<TranslatableField> FindMany()
    {
        var types = Enum.GetValues<NotificationType>();
        return types.Select(t => new TranslatableField
        {
            Value = t.ToString(),
            DisplayValue = NotificationTypeTranslator.ToDisplayValue(t)
        });
    }
}
