using ITControl.Domain.Shared.Attributes;
using ITControl.Domain.Shared.DisplayValues;

namespace ITControl.Domain.Treatments.Enums;

public enum TreatmentStatus
{
    [DisplayValue(typeof(TreatmentsStatuses), nameof(TreatmentsStatuses.Scheduled))]
    Scheduled = 1,
    [DisplayValue(typeof(TreatmentsStatuses), nameof(TreatmentsStatuses.Started))]
    Started = 2,
    [DisplayValue(typeof(TreatmentsStatuses), nameof(TreatmentsStatuses.Finished))]
    Finished = 3,
    [DisplayValue(typeof(TreatmentsStatuses), nameof(TreatmentsStatuses.PartialFinished))]
    PartialFinished = 4,
}