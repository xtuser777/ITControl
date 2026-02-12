namespace ITControl.Presentation.SuppliesMovements.Responses;

public record FindOneSuppliesMovementsDivisionResponse
{
    public Guid? Id { get; set; }
    public string? Name { get; set; } = string.Empty;
}
