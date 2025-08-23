namespace ITControl.Communication.Divisions.Requests;

public class UpdateDivisionsRequest
{
    public string? Name { get; set; }
    public Guid? DepartmentId { get; set; }
    public Guid? UserId { get; set; }
}