using ITControl.Domain.Shared.Attributes;
using ITControl.Domain.Shared.DisplayValues;

namespace ITControl.Domain.Calls.Enums;

public enum CallStatus
{
    [DisplayValue(typeof(CallsStatuses), nameof(CallsStatuses.Open))]
    Open = 1,
    [DisplayValue(typeof(CallsStatuses), nameof(CallsStatuses.InProgress))]
    InProgress = 2,
    [DisplayValue(typeof(CallsStatuses), nameof(CallsStatuses.OnHold))]
    OnHold = 3,
    [DisplayValue(typeof(CallsStatuses), nameof(CallsStatuses.Closed))]
    Closed = 4
}
