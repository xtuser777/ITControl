using ITControl.Domain.Shared.Params2;

namespace ITControl.Domain.Roles.Params;

public record IncludesRolesPagesParams
{
    public bool? Page { get; set; } = null;
}

public record IncludesRolesParams : IncludesParams
{
    public IncludesRolesPagesParams? RolesPages { get; set; } = null;
}
