namespace ITControl.Presentation.SupplementsMovements.Responses;

public record FindOneSupplementsMovementsSupplementResponse
{
    public Guid? Id { get; set; }
    public string? Brand { get; set; } = string.Empty;
    public string? Model { get; set; } = string.Empty;
    public int? Stock { get; set; }
    public string? SupplementType { get; set; } = string.Empty;
}
