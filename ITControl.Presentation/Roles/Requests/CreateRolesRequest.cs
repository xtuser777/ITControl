using System.ComponentModel.DataAnnotations;
using ITControl.Domain.Roles.Entities;
using ITControl.Domain.Roles.Interfaces;
using ITControl.Domain.Roles.Params;
using ITControl.Domain.Roles.Props;
using ITControl.Presentation.Shared.Attributes;
using ITControl.Presentation.Shared.Resources;

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

    public static implicit operator RoleProps(
        CreateRolesRequest request) 
        => new()
        {
            Name = request.Name,
            Active = true,
            RolesPages = [.. request.RolesPages
                .Select(p => new RolePage(
                    Guid.Empty, p.PageId))]
        };
}