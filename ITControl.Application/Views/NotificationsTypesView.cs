using ITControl.Application.Interfaces;
using ITControl.Application.Translators;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Enums;

namespace ITControl.Application.Views;

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
