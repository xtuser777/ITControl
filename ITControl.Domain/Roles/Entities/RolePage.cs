using ITControl.Domain.Roles.Props;

namespace ITControl.Domain.Roles.Entities;

public sealed class RolePage : RolePageProps
{
    public RolePage(Guid? roleId, Guid? pageId)
    {
        Id = Guid.NewGuid();
        RoleId = roleId;
        PageId = pageId;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }
}