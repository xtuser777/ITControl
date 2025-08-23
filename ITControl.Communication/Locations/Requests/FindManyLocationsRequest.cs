using ITControl.Communication.Shared.Requests;

namespace ITControl.Communication.Locations.Requests;

public class FindManyLocationsRequest : PageableRequest
{
    public string? Description { get; set; }
    public Guid? UnitId { get; set; }
    public Guid? UserId { get; set; }
    public Guid? DepartmentId { get; set; }
    public Guid? DivisionId { get; set; }
    public string? OrderByDescription { get; set; }
    public string? OrderByUnit { get; set; }
    public string? OrderByUser { get; set; }
    public string? OrderByDepartment { get; set; }
    public string? OrderByDivision { get; set; }
}