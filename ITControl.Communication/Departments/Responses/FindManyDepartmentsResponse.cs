namespace ITControl.Communication.Departments.Responses;

public class FindManyDepartmentsResponse
{
    public Guid Id { get; set; }
    public string Alias { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}