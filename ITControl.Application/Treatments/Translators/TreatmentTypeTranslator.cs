using ITControl.Application.Shared.Messages.Translate;
using ITControl.Domain.Treatments.Enums;

namespace ITControl.Application.Treatments.Translators;

public abstract class TreatmentTypeTranslator
{
    public static string ToDisplayName(TreatmentType treatmentType)
    {
        return treatmentType switch
        {
            TreatmentType.Presential => TreatmentsTypes.Presential,
            TreatmentType.Remote => TreatmentsTypes.Remote,
            TreatmentType.Phone => TreatmentsTypes.Phone,
            _ => treatmentType.ToString()
        };
    }
}
