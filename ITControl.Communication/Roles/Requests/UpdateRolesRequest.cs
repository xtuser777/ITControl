using ITControl.Communication.Shared.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Roles.Requests;

public class UpdateRolesRequest
{
    [StringMaxLength(100)]
    [Display(Name = "nome")]
    public string? Name { get; set; }

    [BoolValue]
    [Display(Name = "ativo")]
    public bool? Active { get; set; }
    
    [RequiredField]
    [Display(Name = "páginas")]
    public IEnumerable<CreateRolesPagesRequest>? RolesPages { get; set; }
}