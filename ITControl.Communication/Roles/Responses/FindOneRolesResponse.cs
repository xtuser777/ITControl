namespace ITControl.Communication.Roles.Responses;

public class FindOneRolesResponse
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public bool Active { get; set; }
    public IEnumerable<FindOneRolesPagesResponse>? RolesPages { get; set; } = [];
    public IEnumerable<FindOneRolesPageResponse>? Pages { get; set; } = [];
}