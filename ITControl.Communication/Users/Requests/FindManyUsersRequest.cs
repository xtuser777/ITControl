using ITControl.Communication.Shared.Requests;

namespace ITControl.Communication.Users.Requests;

public class FindManyUsersRequest : PageableRequest
{
    public string? Username { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Active { get; set; }
    public string? OrderByUsername { get; set; }
    public string? OrderByName { get; set; }
    public string? OrderByEmail { get; set; }
    public string? OrderByActive { get; set; }
}