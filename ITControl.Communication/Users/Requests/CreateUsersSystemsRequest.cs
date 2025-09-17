using ITControl.Communication.Shared.Attributes;
using ITControl.Communication.Shared.Resources;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Users.Requests;

public class CreateUsersSystemsRequest
{
    [RequiredField]
    [GuidValue]
    [SystemConnection]
    [Display(Name = nameof(SystemId), ResourceType = typeof(DisplayNames))]
    public Guid SystemId { get; set; }
}