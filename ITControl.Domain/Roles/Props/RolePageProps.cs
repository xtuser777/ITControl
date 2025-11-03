using ITControl.Domain.Pages.Entities;
using ITControl.Domain.Roles.Entities;
using ITControl.Domain.Shared.Entities;

namespace ITControl.Domain.Roles.Props;

public class RolePageProps : Entity
{
    public Guid? RoleId { get; set; }
    public Guid? PageId { get; set; }
    public Role? Role { get; set; }
    public Page? Page { get; set; }
}