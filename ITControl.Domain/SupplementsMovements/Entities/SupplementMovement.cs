using ITControl.Domain.Departments.Entities;
using ITControl.Domain.Divisions.Entities;
using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Supplements.Entities;
using ITControl.Domain.Units.Entities;
using ITControl.Domain.Users.Entities;

namespace ITControl.Domain.SupplementsMovements.Entities;

public sealed class SupplementMovement : Entity
{
    public int Quantity { get; private set; }
    public DateOnly MovementDate { get; private set; }
    public string Observation { get; private set; } = string.Empty;
    public Guid SupplementId { get; private set; }
    public Guid UserId { get; private set; }
    public Guid UnitId { get; private set; }
    public Guid DepartmentId { get; private set; }
    public Guid? DivisionId { get; private set; }
    // Navigation properties
    public Supplement? Supplement { get; set; } = null!;
    public User? User { get; set; } = null!;
    public Unit? Unit { get; set; } = null!;
    public Department? Department { get; set; } = null!;
    public Division? Division { get; set; } = null!;

    public SupplementMovement() { }
    
    public SupplementMovement(
        int quantity, 
        DateOnly movementDate, 
        string observation,
        Guid supplementId, 
        Guid userId,
        Guid unitId,
        Guid departmentId, 
        Guid? divisionId = null)
    {
        Id = Guid.NewGuid();
        Quantity = quantity;
        MovementDate = movementDate;
        Observation = observation;
        SupplementId = supplementId;
        UserId = userId;
        UnitId = unitId;
        DepartmentId = departmentId;
        DivisionId = divisionId;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public void Update(
        int? quantity = null, 
        DateOnly? movementDate = null, 
        string? observation = null,
        Guid? supplementId = null, 
        Guid? userId = null,
        Guid? unitId = null,
        Guid? departmentId = null, 
        Guid? divisionId = null)
    {
        if (quantity is not null)
            Quantity = quantity.Value;
        if (movementDate is not null)
            MovementDate = movementDate.Value;
        if (observation is not null)
            Observation = observation;
        if (supplementId is not null)
            SupplementId = supplementId.Value;
        if (userId is not null)
            UserId = userId.Value;
        if (unitId is not null)
            UnitId = unitId.Value;
        if (departmentId is not null)
            DepartmentId = departmentId.Value;
        if (divisionId is not null)
            DivisionId = divisionId;
        UpdatedAt = DateTime.Now;
    }
}
