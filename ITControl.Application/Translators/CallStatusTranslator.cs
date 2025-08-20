namespace ITControl.Application.Translators;
public class CallStatusTranslator
{
    public static string ToDisplayValue(Domain.Enums.CallStatus status)
    {
        return status switch
        {
            Domain.Enums.CallStatus.Open => "Aberto",
            Domain.Enums.CallStatus.InProgress => "Em Andamento",
            Domain.Enums.CallStatus.OnHold => "Em Espera",
            Domain.Enums.CallStatus.Closed => "Fechado",
            _ => status.ToString()
        };
    }
}
