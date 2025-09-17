using ITControl.Communication.Shared.Resources;
using ITControl.Communication.Shared.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Notifications.Requests;

public class UpdateNotificationsRequest
{
    [BoolValue]
    [Display(Name = nameof(IsRead), ResourceType = typeof(DisplayNames))]
    public bool? IsRead { get; set; }
}
