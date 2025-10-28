using ITControl.Domain.Notifications.Enums;
using ITControl.Domain.Shared.Extensions;
using ITControl.Presentation.Notifications.Interfaces;
using ITControl.Presentation.Shared.Responses;

namespace ITControl.Presentation.Notifications.Views;

public class NotificationsReferencesView : INotificationsReferencesView
{
    public IEnumerable<TranslatableField> FindMany()
    {
        var references = Enum.GetValues<NotificationReference>();
        return references.Select(r => new TranslatableField
        {
            Value = r.ToString(),
            DisplayValue = r.GetDisplayValue()
        });
    }
}
