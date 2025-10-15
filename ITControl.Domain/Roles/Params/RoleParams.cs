namespace ITControl.Domain.Roles.Params;

public record RoleParams
{
    public string Name { get; set; } = string.Empty;
    public bool Active { get; set; }
}
