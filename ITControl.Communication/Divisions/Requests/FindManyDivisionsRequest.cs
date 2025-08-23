using ITControl.Communication.Shared.Requests;

namespace ITControl.Communication.Divisions.Requests;

public class FindManyDivisionsRequest : PageableRequest
{
    public string? Name { get; set; }
    public Guid? DepartmentId { get; set; }
    public Guid? UserId { get; set; }
    public string? OrderByName { get; set; }
    public string? OrderByDepartment { get; set; }
    public string? OrderByUser { get; set; }
}