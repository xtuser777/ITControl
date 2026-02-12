namespace ITControl.Presentation.SuppliesMovements.Responses;

public record FindManySuppliesMovementsResponse
{
    public Guid? Id { get; set; }
    public int? Quantity { get; set; }
    public DateOnly? MovementDate { get; set; }
    public string? Observation { get; set; } = string.Empty;
    public Guid? SupplyId { get; set; }
    public Guid? UserId { get; set; }
    public Guid? UnitId { get; set; }
    public Guid? DepartmentId { get; set; }
    public Guid? DivisionId { get; set; }
}
