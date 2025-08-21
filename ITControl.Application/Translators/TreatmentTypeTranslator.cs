using ITControl.Domain.Enums;

namespace ITControl.Application.Translators;

public class TreatmentTypeTranslator
{
    public static string ToDisplayName(TreatmentType treatmentType)
    {
        return treatmentType switch
        {
            TreatmentType.Presential => "Presencial",
            TreatmentType.Remote => "Remoto",
            TreatmentType.Phone => "Telefônico",
            _ => treatmentType.ToString()
        };
    }
}
