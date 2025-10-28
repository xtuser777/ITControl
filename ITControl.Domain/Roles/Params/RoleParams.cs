using ITControl.Domain.Roles.Entities;
using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Roles.Params;

public record RoleParams : EntityParams
{
    public string Name { get; init; } = string.Empty;
    public bool Active { get; init; }
    public IEnumerable<RolePage> Pages { get; set; } = [];
}
