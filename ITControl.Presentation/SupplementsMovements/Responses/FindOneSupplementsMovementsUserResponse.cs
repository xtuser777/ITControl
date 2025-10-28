namespace ITControl.Presentation.SupplementsMovements.Responses;

public record FindOneSupplementsMovementsUserResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
