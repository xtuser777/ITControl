using ITControl.Application.Notifications.Interfaces;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Notifications.Enums;

namespace ITControl.Application.Notifications.Views;

public class NotificationsReferencesView : INotificationsReferencesView
{
    public IEnumerable<TranslatableField> FindMany()
    {
        var references = Enum.GetValues<NotificationReference>();
        return references.Select(r => new TranslatableField
        {
            Value = r.ToString(),
            DisplayValue = Translators.NotificationReferenceTranslator.ToDisplayValue(r)
        });
    }
}
