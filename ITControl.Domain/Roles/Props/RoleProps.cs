using ITControl.Domain.Roles.Entities;
using ITControl.Domain.Shared.Entities;

namespace ITControl.Domain.Roles.Props;

public class RoleProps : Entity
{
    public string? Name { get; set; }
    public bool? Active { get; set; }
    public ICollection<RolePage>? RolesPages { get; set; }
}