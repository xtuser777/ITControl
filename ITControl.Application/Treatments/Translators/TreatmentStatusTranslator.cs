using ITControl.Application.Shared.Messages.Translate;
using ITControl.Domain.Treatments.Enums;

namespace ITControl.Application.Treatments.Translators;

public abstract class TreatmentStatusTranslator
{
    public static string ToDisplayName(TreatmentStatus treatmentStatus)
    {
        return treatmentStatus switch
        {
            TreatmentStatus.Started => TreatmentsStatuses.Started,
            TreatmentStatus.Scheduled => TreatmentsStatuses.Scheduled,
            TreatmentStatus.PartialFinished => TreatmentsStatuses.PartialFinished,
            TreatmentStatus.Finished => TreatmentsStatuses.Finished,
            _ => treatmentStatus.ToString()
        };
    }
}
