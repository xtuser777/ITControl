namespace ITControl.Communication.Locations.Requests;

public class CreateLocationsRequest
{
    public string Description { get; set; } = string.Empty;
    public Guid UnitId { get; set; }
    public Guid UserId { get; set; }
    public Guid DepartmentId { get; set; }
    public Guid? DivisionId { get; set; }
}