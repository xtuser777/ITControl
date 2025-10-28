using ITControl.Domain.Notifications.Enums;
using ITControl.Domain.Shared.Extensions;
using ITControl.Presentation.Notifications.Interfaces;
using ITControl.Presentation.Shared.Responses;

namespace ITControl.Presentation.Notifications.Views;

public class NotificationsTypesView : INotificationsTypesView
{
    public IEnumerable<TranslatableField> FindMany()
    {
        var types = Enum.GetValues<NotificationType>();
        return types.Select(t => new TranslatableField
        {
            Value = t.ToString(),
            DisplayValue = t.GetDisplayValue()
        });
    }
}
