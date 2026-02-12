namespace ITControl.Presentation.SuppliesMovements.Responses;

public record FindOneSuppliesMovementsDepartmentResponse
{
    public Guid? Id { get; set; }
    public string? Alias { get; set; } = string.Empty;
    public string? Name { get; set; } = string.Empty;
}
