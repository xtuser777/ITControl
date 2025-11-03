namespace ITControl.Presentation.SupplementsMovements.Responses;

public record FindOneSupplementsMovementsDepartmentResponse
{
    public Guid? Id { get; set; }
    public string? Alias { get; set; } = string.Empty;
    public string? Name { get; set; } = string.Empty;
}
