using ITControl.Communication.Shared.Requests;

namespace ITControl.Communication.Roles.Requests;

public record FindManyRolesRequest : PageableRequest
{
    public string? Name { get; set; }
    public string? Active { get; set; }
    public string? OrderByName { get; set; }
    public string? OrderByActive { get; set; }
}