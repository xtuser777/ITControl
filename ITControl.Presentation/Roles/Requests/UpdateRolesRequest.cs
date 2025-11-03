using System.ComponentModel.DataAnnotations;
using ITControl.Domain.Roles.Entities;
using ITControl.Domain.Roles.Interfaces;
using ITControl.Domain.Roles.Params;
using ITControl.Domain.Roles.Props;
using ITControl.Presentation.Shared.Attributes;
using ITControl.Presentation.Shared.Resources;

namespace ITControl.Presentation.Roles.Requests;

public record UpdateRolesRequest
{
    [StringMinLength(1)]
    [StringMaxLength(100)]
    [UniqueField<Role>(typeof(IRolesRepository), typeof(ExclusiveRolesParams))]
    [Display(Name = nameof(Name), ResourceType = typeof(DisplayNames))]
    public string? Name { get; set; }

    [BoolValue]
    [Display(Name = nameof(Active), ResourceType = typeof(DisplayNames))]
    public bool? Active { get; set; }
    
    [RequiredField]
    [Display(Name = nameof(RolesPages), ResourceType = typeof(DisplayNames))]
    public IEnumerable<CreateRolesPagesRequest>? RolesPages { get; set; }

    public static implicit operator RoleProps(
        UpdateRolesRequest request) => new()
    {
        Name = request.Name,
        Active = request.Active,
        RolesPages = request.RolesPages!
            .Select(p => new RolePage(
                Guid.Empty, p.PageId)) as ICollection<RolePage>
    };
}