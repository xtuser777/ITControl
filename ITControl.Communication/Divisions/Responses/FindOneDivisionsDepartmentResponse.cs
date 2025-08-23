namespace ITControl.Communication.Divisions.Responses;

public class FindOneDivisionsDepartmentResponse
{
    public Guid Id { get; set; }
    public string Alias { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}