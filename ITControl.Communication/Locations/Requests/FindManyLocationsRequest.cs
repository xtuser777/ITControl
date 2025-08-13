using ITControl.Communication.Shared.Requests;

namespace ITControl.Communication.Locations.Requests;

public class FindManyLocationsRequest : PageableRequest
{
    public string? Description { get; set; }
    public string? UnitId { get; set; }
    public string? UserId { get; set; }
    public string? DepartmentId { get; set; }
    public string? DivisionId { get; set; }
    public string? OrderByDescription { get; set; }
    public string? OrderByUnit { get; set; }
    public string? OrderByUser { get; set; }
    public string? OrderByDepartment { get; set; }
    public string? OrderByDivision { get; set; }
}