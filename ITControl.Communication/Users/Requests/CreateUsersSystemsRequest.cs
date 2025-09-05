using ITControl.Communication.Shared.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Users.Requests;

public class CreateUsersSystemsRequest
{
    [RequiredField]
    [GuidConverter]
    [GuidValue]
    [Display(Name = "sistema")]
    public Guid SystemId { get; set; }
}