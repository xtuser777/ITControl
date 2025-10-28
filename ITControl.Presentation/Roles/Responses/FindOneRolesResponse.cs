namespace ITControl.Presentation.Roles.Responses;

public record FindOneRolesResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool Active { get; set; }
    public IEnumerable<FindOneRolesPagesResponse>? RolesPages { get; set; } = [];
    public IEnumerable<FindOneRolesPageResponse>? Pages { get; set; } = [];
}