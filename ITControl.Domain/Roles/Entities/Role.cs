using ITControl.Domain.Roles.Props;

namespace ITControl.Domain.Roles.Entities;

public sealed class Role : RoleProps
{
    public Role()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public Role(RoleProps @params)
    {
        Assign(@params);
    }

    public void Update(RoleProps @params)
    {
        AssignUpdate(@params);
    }
}