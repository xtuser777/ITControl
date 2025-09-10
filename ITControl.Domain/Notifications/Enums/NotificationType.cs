using ITControl.Domain.Shared.Attributes;
using ITControl.Domain.Shared.DisplayValues;

namespace ITControl.Domain.Notifications.Enums;

public enum NotificationType
{
    [DisplayValue(typeof(NotificationsTypes), nameof(NotificationsTypes.Info))]
    Info = 1,
    [DisplayValue(typeof(NotificationsTypes), nameof(NotificationsTypes.Warning))]
    Warning = 2,
    [DisplayValue(typeof(NotificationsTypes), nameof(NotificationsTypes.Error))]
    Error = 3,
    [DisplayValue(typeof(NotificationsTypes), nameof(NotificationsTypes.Success))]
    Success = 4
}
