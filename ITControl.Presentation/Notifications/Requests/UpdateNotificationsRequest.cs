using System.ComponentModel.DataAnnotations;
using ITControl.Presentation.Shared.Attributes;
using ITControl.Presentation.Shared.Resources;
using ITControl.Domain.Notifications.Params;
using ITControl.Domain.Notifications.Props;

namespace ITControl.Presentation.Notifications.Requests;

public record UpdateNotificationsRequest
{
    [BoolValue]
    [Display(Name = nameof(IsRead), ResourceType = typeof(DisplayNames))]
    public bool? IsRead { get; set; }

    public static implicit operator NotificationProps(
        UpdateNotificationsRequest request)
    {
        return new NotificationProps
        {
            IsRead = request.IsRead
        };
    }
}
