using ITControl.Communication.Shared.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Users.Requests;

public class DeleteUsersRequest
{
    [RequiredField]
    [GuidConverter]
    [GuidValue]
    [Display(Name = "usu�rio logado")]
    public Guid LoggedUserId { get; set; }
}