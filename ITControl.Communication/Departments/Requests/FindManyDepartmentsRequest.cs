using ITControl.Communication.Shared.Requests;

namespace ITControl.Communication.Departments.Requests;

public class FindManyDepartmentsRequest : PageableRequest
{
    public string? Alias { get; set; }
    public string? Name { get; set; }
    public Guid? UserId { get; set; }
    public string? OrderByAlias { get; set; }
    public string? OrderByName { get; set; }
    public string? OrderByUser { get; set; }
}