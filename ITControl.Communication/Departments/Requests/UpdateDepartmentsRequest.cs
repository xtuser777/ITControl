namespace ITControl.Communication.Departments.Requests;

public class UpdateDepartmentsRequest
{
    public string? Alias { get; set; }
    public string? Name { get; set; }
    public Guid? UserId { get; set; }
}