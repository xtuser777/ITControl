using ITControl.Domain.Enums;

namespace ITControl.Application.Translators;

public class TreatmentStatusTranslator
{
    public static string ToDisplayName(TreatmentStatus treatmentStatus)
    {
        return treatmentStatus switch
        {
            TreatmentStatus.Started => "Iniciado",
            TreatmentStatus.Scheduled => "Agendado",
            TreatmentStatus.PartialFinished => "Finalizado parcialmente",
            TreatmentStatus.Finished => "Finalizado",
            _ => treatmentStatus.ToString()
        };
    }
}
