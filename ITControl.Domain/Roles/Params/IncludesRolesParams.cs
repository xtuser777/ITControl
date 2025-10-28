using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Roles.Params;

public record IncludesRolesPagesParams
{
    public bool? Page { get; set; } 
}

public record IncludesRolesParams : IncludesParams
{
    public IncludesRolesPagesParams? RolesPages { get; set; }
}
