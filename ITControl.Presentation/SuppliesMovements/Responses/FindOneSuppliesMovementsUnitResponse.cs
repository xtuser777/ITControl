namespace ITControl.Presentation.SuppliesMovements.Responses;

public record FindOneSuppliesMovementsUnitResponse
{
    public Guid? Id { get; set; }
    public string? Name { get; set; } = string.Empty;
}
