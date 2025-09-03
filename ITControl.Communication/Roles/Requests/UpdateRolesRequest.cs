using ITControl.Communication.Shared.Attributes;
using ITControl.Domain.Shared.Messages;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Roles.Requests;

public class UpdateRolesRequest
{
    [MaxLength(100, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MAX_LENGTH")]
    [Display(Name = "nome")]
    public string? Name { get; set; }

    [BoolValue]
    [Display(Name = "ativo")]
    public bool? Active { get; set; }
    
    [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MAX_LENGTH")]
    [Display(Name = "páginas")]
    public IEnumerable<CreateRolesPagesRequest>? RolesPages { get; set; }
}