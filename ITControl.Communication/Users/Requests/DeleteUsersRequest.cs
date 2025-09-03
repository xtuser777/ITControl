using ITControl.Communication.Shared.Attributes;
using ITControl.Domain.Shared.Messages;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Users.Requests;

public class DeleteUsersRequest
{
    [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "REQUIRED")]
    [GuidValue]
    [Display(Name = "usuário logado")]
    public Guid LoggedUserId { get; set; }
}