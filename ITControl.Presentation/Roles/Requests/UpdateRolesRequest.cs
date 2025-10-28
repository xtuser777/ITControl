using System.ComponentModel.DataAnnotations;
using ITControl.Presentation.Shared.Attributes;
using ITControl.Presentation.Shared.Resources;
using ITControl.Domain.Roles.Entities;
using ITControl.Domain.Roles.Interfaces;
using ITControl.Domain.Roles.Params;

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

    public static implicit operator UpdateRoleParams(
        UpdateRolesRequest request) => new()
    {
        Name = request.Name,
        Active = request.Active,
        Pages = request.RolesPages!
            .Select(rp => new RolePage(
                Guid.Empty, rp.PageId))
    };
}