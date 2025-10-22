namespace ITControl.Domain.SupplementsMovements.Params;

public record UpdateSupplementMovementParams
{
    public int? Quantity { get; init; }
    public DateOnly? MovementDate { get; init; }
    public string? Observation { get; init; }
    public Guid? SupplementId { get; init; }
    public Guid? UserId { get; init; }
    public Guid? UnitId { get; init; }
    public Guid? DepartmentId { get; init; }
    public Guid? DivisionId { get; init; }
}