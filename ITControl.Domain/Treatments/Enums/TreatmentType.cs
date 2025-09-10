using ITControl.Domain.Shared.Attributes;
using ITControl.Domain.Shared.DisplayValues;

namespace ITControl.Domain.Treatments.Enums;

public enum TreatmentType
{
    [DisplayValue(typeof(TreatmentsTypes), nameof(TreatmentsTypes.Presential))]
    Presential = 1,
    [DisplayValue(typeof(TreatmentsTypes), nameof(TreatmentsTypes.Remote))]
    Remote = 2,
    [DisplayValue(typeof(TreatmentsTypes), nameof(TreatmentsTypes.Phone))]
    Phone = 3,
}