using System.ComponentModel.DataAnnotations;
using ITControl.Presentation.Shared.Attributes;
using ITControl.Presentation.Shared.Resources;
using ITControl.Domain.Notifications.Params;

namespace ITControl.Presentation.Notifications.Requests;

public record UpdateNotificationsRequest
{
    [BoolValue]
    [Display(Name = nameof(IsRead), ResourceType = typeof(DisplayNames))]
    public bool? IsRead { get; set; }

    public static implicit operator UpdateNotificationParams(
        UpdateNotificationsRequest request)
    {
        return new UpdateNotificationParams
        {
            IsRead = request.IsRead
        };
    }
}
