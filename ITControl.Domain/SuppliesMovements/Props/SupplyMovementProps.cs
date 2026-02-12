using ITControl.Domain.Departments.Entities;
using ITControl.Domain.Divisions.Entities;
using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Supplies.Entities;
using ITControl.Domain.Units.Entities;
using ITControl.Domain.Users.Entities;

namespace ITControl.Domain.SuppliesMovements.Props;

public class SupplyMovementProps : Entity
{
    public int? Quantity { get; set; }
    public DateOnly? MovementDate { get; set; }
    public string? Observation { get; set; }
    public Guid? SupplyId { get; set; }
    public Guid? UserId { get; set; }
    public Guid? UnitId { get; set; }
    public Guid? DepartmentId { get; set; }
    public Guid? DivisionId { get; set; }
    // Navigation properties
    public Supply? Supply { get; set; }
    public User? User { get; set; }
    public Unit? Unit { get; set; }
    public Department? Department { get; set; }
    public Division? Division { get; set; }
}