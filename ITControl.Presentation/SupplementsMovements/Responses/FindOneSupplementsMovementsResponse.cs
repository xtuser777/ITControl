namespace ITControl.Presentation.SupplementsMovements.Responses;

public record FindOneSupplementsMovementsResponse
{
    public Guid Id { get; set; }
    public int Quantity { get; set; }
    public DateOnly MovementDate { get; set; }
    public string Observation { get; set; } = string.Empty;
    public Guid SupplementId { get; set; }
    public Guid UserId { get; set; }
    public Guid UnitId { get; set; }
    public Guid DepartmentId { get; set; }
    public Guid? DivisionId { get; set; }
    public FindOneSupplementsMovementsSupplementResponse? Supplement { get; set; }
    public FindOneSupplementsMovementsUserResponse? User { get; set; }
    public FindOneSupplementsMovementsUnitResponse? Unit { get; set; }
    public FindOneSupplementsMovementsDepartmentResponse? Department { get; set; }
    public FindOneSupplementsMovementsDivisionResponse? Division { get; set; }
}
