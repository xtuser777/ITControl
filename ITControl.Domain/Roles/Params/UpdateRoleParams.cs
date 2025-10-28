using ITControl.Domain.Roles.Entities;
using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Roles.Params;

public record UpdateRoleParams : UpdateEntityParams
{
    public string? Name { get; init; } = null;
    public bool? Active { get; init; } = null;
    public IEnumerable<RolePage> Pages { get; set; } = [];
}
