using ITControl.Application.Shared.Messages.Translate;
using ITControl.Domain.Notifications.Enums;

namespace ITControl.Application.Notifications.Translators;

public abstract class NotificationReferenceTranslator
{
    public static string ToDisplayValue(NotificationReference notificationReference) => notificationReference switch
    {
        NotificationReference.Call => NotificationsReferences.Call,
        NotificationReference.Appointment => NotificationsReferences.Appointment,
        NotificationReference.Treatment => NotificationsReferences.Treatment,
        _ => notificationReference.ToString()
    };
}
