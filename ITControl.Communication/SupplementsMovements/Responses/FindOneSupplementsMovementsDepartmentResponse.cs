namespace ITControl.Communication.SupplementsMovements.Responses;

public class FindOneSupplementsMovementsDepartmentResponse
{
    public Guid Id { get; set; }
    public string Alias { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}
