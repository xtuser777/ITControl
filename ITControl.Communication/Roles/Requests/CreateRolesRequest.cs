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
    [Display(Name = "páginas")]
    public IEnumerable<CreateRolesPagesRequest> RolesPages { get; set; } = [];
}