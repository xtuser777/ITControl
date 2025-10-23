using ITControl.Domain.Shared.Params2;

namespace ITControl.Domain.Roles.Params;

public record IncludesRolesPagesParams : IncludesParams
{
    public bool? Page { get; set; } = null;
}

public record IncludesRolesParams
{
    public IncludesRolesPagesParams? RolesPages { get; set; } = null;
}
