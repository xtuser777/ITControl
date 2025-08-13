namespace ITControl.Communication.Locations.Requests;

public class CreateLocationsRequest
{
    public string Description { get; set; } = string.Empty;
    public string UnitId { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
    public string DepartmentId { get; set; } = string.Empty;
    public string? DivisionId { get; set; }
}