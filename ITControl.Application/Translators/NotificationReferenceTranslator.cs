using ITControl.Domain.Enums;

namespace ITControl.Application.Translators;

public class NotificationReferenceTranslator
{
    public static string ToDisplayValue(NotificationReference notificationReference) => notificationReference switch
    {
        NotificationReference.Call => "Chamado",
        NotificationReference.Appointment => "Agendamento",
        NotificationReference.Treatment => "Atendimento",
        _ => "Unknown"
    };
}
