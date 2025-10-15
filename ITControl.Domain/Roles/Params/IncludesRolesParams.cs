namespace ITControl.Domain.Roles.Params;

public record IncludesRolesPagesParams
{
    public bool? Page { get; set; } = null;
}

public record IncludesRolesParams
{
    public IncludesRolesPagesParams? RolesPages { get; set; } = null;
}
