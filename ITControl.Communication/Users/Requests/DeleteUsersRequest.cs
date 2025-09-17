using ITControl.Communication.Shared.Attributes;
using ITControl.Communication.Shared.Resources;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Users.Requests;

public class DeleteUsersRequest
{
    [RequiredField]
    [GuidValue]
    [Display(Name = nameof(LoggedUserId), ResourceType = typeof(DisplayNames))]
    public Guid LoggedUserId { get; set; }
}