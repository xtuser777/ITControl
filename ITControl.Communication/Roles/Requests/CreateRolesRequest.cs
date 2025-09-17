using ITControl.Communication.Shared.Resources;
using ITControl.Communication.Shared.Attributes;
using System.ComponentModel.DataAnnotations;
namespace ITControl.Communication.Roles.Requests;

public class CreateRolesRequest
{
    [RequiredField]
    [StringMaxLength(100)]
    [Display(Name = nameof(Name), ResourceType = typeof(DisplayNames))]
    public string Name { get; set; } = string.Empty;

    [RequiredField]
    [Display(Name = nameof(RolesPages), ResourceType = typeof(DisplayNames))]
    public IEnumerable<CreateRolesPagesRequest> RolesPages { get; set; } = [];
}