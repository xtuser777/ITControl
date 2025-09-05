using ITControl.Domain.Entities;
using ITControl.Domain.Pages.Entities;
using ITControl.Domain.Validation;

namespace ITControl.Domain.Roles.Entities;

public sealed class RolePage : Entity
{
    public Guid RoleId { get; set; }
    public Guid PageId { get; set; }
    public Role? Role { get; set; }
    public Page? Page { get; set; }

    public RolePage(Guid roleId, Guid pageId)
    {
        Id = Guid.NewGuid();
        RoleId = roleId;
        PageId = pageId;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public void Update(Guid? roleId, Guid? pageId)
    {
        RoleId = roleId ?? RoleId;
        PageId = pageId ?? PageId;
        UpdatedAt = DateTime.Now;
    }
}