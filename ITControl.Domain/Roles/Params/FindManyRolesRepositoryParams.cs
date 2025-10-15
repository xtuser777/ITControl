namespace ITControl.Domain.Roles.Params;

public record FindManyRolesRepositoryParams
{
    public string? Name { get; set; } = null;
    public bool? Active { get; set; } = null;
}
