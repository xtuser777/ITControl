namespace ITControl.Domain.Roles.Params;

public record UpdateRoleParams
{
    public string? Name { get; set; } = null;
    public bool? Active { get; set; } = null;
}
