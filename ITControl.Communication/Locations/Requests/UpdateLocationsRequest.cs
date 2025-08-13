namespace ITControl.Communication.Locations.Requests;

public class UpdateLocationsRequest
{
    public string? Description { get; set; }
    public string? UnitId { get; set; }
    public string? UserId { get; set; }
    public string? DepartmentId { get; set; }
    public string? DivisionId { get; set; }
}