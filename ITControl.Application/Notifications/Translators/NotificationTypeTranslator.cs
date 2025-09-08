using ITControl.Application.Shared.Messages.Translate;
using ITControl.Domain.Notifications.Enums;

namespace ITControl.Application.Notifications.Translators;

public abstract class NotificationTypeTranslator
{
    public static string ToDisplayValue(NotificationType type) => type switch
    {
        NotificationType.Info => NotificationsTypes.Info,
        NotificationType.Warning => NotificationsTypes.Warning,
        NotificationType.Error => NotificationsTypes.Error,
        NotificationType.Success => NotificationsTypes.Success,
        _ => type.ToString()
    };
}
