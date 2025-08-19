namespace ITControl.Communication.Roles.Requests;

public class UpdateRolesRequest
{
    public string? Name { get; set; }
    public bool? Active { get; set; }
    public IEnumerable<CreateRolesPagesRequest>? RolesPages { get; set; }
}