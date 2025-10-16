using ITControl.Communication.Shared.Resources;
using ITControl.Communication.Shared.Attributes;
using System.ComponentModel.DataAnnotations;
using ITControl.Domain.Notifications.Params;

namespace ITControl.Communication.Notifications.Requests;

public record UpdateNotificationsRequest
{
    [BoolValue]
    [Display(Name = nameof(IsRead), ResourceType = typeof(DisplayNames))]
    public bool? IsRead { get; set; }

    public static implicit operator UpdateNotificationParams(UpdateNotificationsRequest request)
    {
        return new UpdateNotificationParams
        {
            IsRead = request.IsRead
        };
    }
}
