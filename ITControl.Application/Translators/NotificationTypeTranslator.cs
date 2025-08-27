using ITControl.Domain.Enums;

namespace ITControl.Application.Translators;

public class NotificationTypeTranslator
{
    public static string ToDisplayValue(NotificationType type) => type switch
    {
        NotificationType.Info => "Informação",
        NotificationType.Warning => "Atenção",
        NotificationType.Error => "Erro",
        NotificationType.Success => "Sucesso",
        _ => "Unknown"
    };
}
