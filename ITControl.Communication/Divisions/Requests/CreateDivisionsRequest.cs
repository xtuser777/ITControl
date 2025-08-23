namespace ITControl.Communication.Divisions.Requests;

public class CreateDivisionsRequest
{
    public string Name { get; set; } = string.Empty;
    public Guid DepartmentId { get; set; }
    public Guid UserId { get; set; }
}