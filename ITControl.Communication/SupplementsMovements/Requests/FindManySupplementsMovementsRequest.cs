using ITControl.Communication.Shared.Requests;

namespace ITControl.Communication.SupplementsMovements.Requests;

public class FindManySupplementsMovementsRequest : PageableRequest
{
    public int? Quantity { get; set; }
    public DateOnly? MovementDate { get; set; }
    public string? Observation { get; set; }
    public Guid? SupplementId { get; set; }
    public Guid? UserId { get; set; }
    public Guid? UnitId { get; set; }
    public Guid? DepartmentId { get; set; }
    public Guid? DivisionId { get; set; }
    public string? OrderByQuantity { get; set; }
    public string? OrderByMovementDate { get; set; }
    public string? OrderByObservation { get; set; }
    public string? OrderBySupplement { get; set; }
    public string? OrderByUser { get; set; }
    public string? OrderByUnit { get; set; }
    public string? OrderByDepartment { get; set; }
    public string? OrderByDivision { get; set; }
}
