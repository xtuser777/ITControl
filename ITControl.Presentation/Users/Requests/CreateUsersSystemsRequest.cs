using System.ComponentModel.DataAnnotations;
using ITControl.Presentation.Shared.Attributes;
using ITControl.Presentation.Shared.Resources;

namespace ITControl.Presentation.Users.Requests;

public class CreateUsersSystemsRequest
{
    [RequiredField]
    [GuidValue]
    [SystemConnection]
    [Display(Name = nameof(SystemId), ResourceType = typeof(DisplayNames))]
    public Guid SystemId { get; set; }
}