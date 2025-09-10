using ITControl.Domain.Shared.Attributes;
using ITControl.Domain.Shared.DisplayValues;

namespace ITControl.Domain.Notifications.Enums;

public enum NotificationReference
{
    [DisplayValue(typeof(NotificationsReferences), nameof(NotificationsReferences.Call))]
    Call = 1,
    [DisplayValue(typeof(NotificationsReferences), nameof(NotificationsReferences.Appointment))]
    Appointment = 2,
    [DisplayValue(typeof(NotificationsReferences), nameof(NotificationsReferences.Treatment))]
    Treatment = 3,
}
