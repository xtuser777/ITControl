namespace ITControl.Presentation.SuppliesMovements.Responses;

public record FindOneSuppliesMovementsSupplyResponse
{
    public Guid? Id { get; set; }
    public string? Brand { get; set; } = string.Empty;
    public string? Model { get; set; } = string.Empty;
    public int? Stock { get; set; }
    public string? SupplyType { get; set; } = string.Empty;
}
