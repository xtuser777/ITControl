using ITControl.Domain.Roles.Params;
using ITControl.Domain.Shared.Entities;

namespace ITControl.Domain.Roles.Entities;

public sealed class Role : Entity
{
    public string Name { get; set; } = string.Empty;
    public bool Active { get; set; }

    public ICollection<RolePage>? RolesPages { get; set; }

    public Role() { }

    public Role(RoleParams @params)
    {
        Id = Guid.NewGuid();
        Name = @params.Name;
        Active = @params.Active;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public void Update(UpdateRoleParams @params)
    {
        Name = @params.Name ?? Name;
        Active = @params.Active ?? Active;
        UpdatedAt = DateTime.Now;
    }
}