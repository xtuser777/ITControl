namespace ITControl.Domain.Roles.Params;

public record OrderByRolesRepositoryParams
{
    public string? Name { get; set; } = null;
    public string? Active { get; set; } = null;
}
