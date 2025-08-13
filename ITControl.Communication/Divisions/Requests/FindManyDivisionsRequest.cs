using ITControl.Communication.Shared.Requests;

namespace ITControl.Communication.Divisions.Requests;

public class FindManyDivisionsRequest : PageableRequest
{
    public string? Name { get; set; }
    public string? DepartmentId { get; set; }
    public string? UserId { get; set; }
    public string? OrderByName { get; set; }
    public string? OrderByDepartment { get; set; }
    public string? OrderByUser { get; set; }
}