namespace ITControl.Presentation.SupplementsMovements.Responses;

public record FindOneSupplementsMovementsDivisionResponse
{
    public Guid? Id { get; set; }
    public string? Name { get; set; } = string.Empty;
}
