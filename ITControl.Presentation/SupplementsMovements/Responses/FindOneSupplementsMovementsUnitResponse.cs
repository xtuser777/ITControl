namespace ITControl.Presentation.SupplementsMovements.Responses;

public record FindOneSupplementsMovementsUnitResponse
{
    public Guid? Id { get; set; }
    public string? Name { get; set; } = string.Empty;
}
