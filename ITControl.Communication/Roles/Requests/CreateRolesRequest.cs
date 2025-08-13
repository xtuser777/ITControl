namespace ITControl.Communication.Roles.Requests;

public class CreateRolesRequest
{
    public string Name { get; set; } = string.Empty;
    public IEnumerable<CreateRolesPagesRequest> RolesPages { get; set; } = [];
}