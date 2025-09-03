using ITControl.Domain.Shared.Messages;
using System.ComponentModel.DataAnnotations;
namespace ITControl.Communication.Roles.Requests;

public class CreateRolesRequest
{
    [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "REQUIRED")]
    [MaxLength(100, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MAX_LENGTH")]
    [Display(Name = "nome")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "REQUIRED")]
    [Display(Name = "páginas")]
    public IEnumerable<CreateRolesPagesRequest> RolesPages { get; set; } = [];
}