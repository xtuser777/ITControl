using ITControl.Communication.Shared.Attributes;
using System.ComponentModel;

namespace ITControl.Communication.Notifications.Requests;

public class UpdateNotificationsRequest
{
    [BoolValue]
    [DisplayName("lida")]
    public bool? IsRead { get; set; }
}
