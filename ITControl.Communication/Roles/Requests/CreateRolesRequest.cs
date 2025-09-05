using ITControl.Communication.Shared.Attributes;
using System.ComponentModel.DataAnnotations;
namespace ITControl.Communication.Roles.Requests;

public class CreateRolesRequest
{
    [RequiredField]
    [StringMaxLength(100)]
    [Display(Name = "nome")]
    public string Name { get; set; } = string.Empty;

    [RequiredField]
    [Display(Name = "p�ginas")]
    public IEnumerable<CreateRolesPagesRequest> RolesPages { get; set; } = [];
}