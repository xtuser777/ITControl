namespace ITControl.Communication.Locations.Responses;

public class FindOneLocationsDepartmentResponse
{
    public Guid Id { get; set; }
    public string Alias { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty; 
}