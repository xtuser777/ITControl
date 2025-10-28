using System.ComponentModel.DataAnnotations;
using ITControl.Presentation.Shared.Attributes;
using ITControl.Presentation.Shared.Resources;
using ITControl.Domain.Roles.Entities;
using ITControl.Domain.Roles.Interfaces;
using ITControl.Domain.Roles.Params;

namespace ITControl.Presentation.Roles.Requests;

public record CreateRolesRequest
{
    [RequiredField]
    [StringMaxLength(100)]
    [UniqueField<Role>(typeof(IRolesRepository), typeof(ExistsRolesParams))]
    [Display(Name = nameof(Name), ResourceType = typeof(DisplayNames))]
    public string Name { get; set; } = string.Empty;

    [RequiredField]
    [Display(Name = nameof(RolesPages), ResourceType = typeof(DisplayNames))]
    public IEnumerable<CreateRolesPagesRequest> RolesPages { get; set; } = [];

    public static implicit operator RoleParams(
        CreateRolesRequest request) 
        => new()
        {
            Name = request.Name,
            Active = true,
            Pages = request.RolesPages
                .Select(p => new RolePage(
                    Guid.Empty, p.PageId))
        };
}