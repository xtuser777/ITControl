using ITControl.Communication.Shared.Resources;
using ITControl.Communication.Shared.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ITControl.Communication.Roles.Requests;

public class UpdateRolesRequest
{
    [StringMaxLength(100)]
    [Display(Name = nameof(Name), ResourceType = typeof(DisplayNames))]
    public string? Name { get; set; }

    [BoolValue]
    [Display(Name = nameof(Active), ResourceType = typeof(DisplayNames))]
    public bool? Active { get; set; }
    
    [RequiredField]
    [Display(Name = nameof(RolesPages), ResourceType = typeof(DisplayNames))]
    public IEnumerable<CreateRolesPagesRequest>? RolesPages { get; set; }
}