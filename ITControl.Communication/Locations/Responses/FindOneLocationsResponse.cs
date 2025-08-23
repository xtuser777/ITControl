namespace ITControl.Communication.Locations.Responses;

public class FindOneLocationsResponse
{
    public Guid Id { get; set; } 
    public string Description { get; set; } = string.Empty;
    public Guid UnitId { get; set; } 
    public Guid UserId { get; set; } 
    public Guid DepartmentId { get; set; } 
    public Guid? DivisionId { get; set; }
    public FindOneLocationsDepartmentResponse? Department { get; set; }
    public FindOneLocationsDivisionResponse? Division { get; set; }
}