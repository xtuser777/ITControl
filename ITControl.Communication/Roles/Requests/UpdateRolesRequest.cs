using ITControl.Domain.Shared.Messages;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Roles.Requests;

public class UpdateRolesRequest
{
    [MaxLength(100, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MAX_LENGTH")]
    public string? Name { get; set; }
    public bool? Active { get; set; }
    
    [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MAX_LENGTH")]
    public IEnumerable<CreateRolesPagesRequest>? RolesPages { get; set; }
}