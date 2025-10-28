namespace ITControl.Presentation.Roles.Responses;

public record FindManyRolesResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool Active { get; set; }
}