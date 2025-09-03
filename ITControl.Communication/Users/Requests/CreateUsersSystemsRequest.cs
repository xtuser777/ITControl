using ITControl.Communication.Shared.Attributes;
using ITControl.Domain.Shared.Messages;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Users.Requests;

public class CreateUsersSystemsRequest
{
    [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "REQUIRED")]
    [GuidValue]
    [Display(Name = "sistema")]
    public Guid SystemId { get; set; }
}