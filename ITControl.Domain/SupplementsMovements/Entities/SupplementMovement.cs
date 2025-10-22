using ITControl.Domain.Departments.Entities;
using ITControl.Domain.Divisions.Entities;
using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Supplements.Entities;
using ITControl.Domain.SupplementsMovements.Params;
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
    
    public SupplementMovement(SupplementMovementParams @params)
    {
        Id = Guid.NewGuid();
        Quantity = @params.Quantity;
        MovementDate = @params.MovementDate;
        Observation = @params.Observation;
        SupplementId = @params.SupplementId;
        UserId = @params.UserId;
        UnitId = @params.UnitId;
        DepartmentId = @params.DepartmentId;
        DivisionId = @params.DivisionId;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public void Update(UpdateSupplementMovementParams @params)
    {
        
        Quantity = @params.Quantity ?? Quantity;
        MovementDate = @params.MovementDate ?? MovementDate;
        Observation = @params.Observation ?? Observation;
        SupplementId = @params.SupplementId ?? SupplementId;
        UserId = @params.UserId ?? UserId;
        UnitId = @params.UnitId ?? UnitId;
        DepartmentId = @params.DepartmentId ?? DepartmentId;
        DivisionId = @params.DivisionId ?? DivisionId;
        UpdatedAt = DateTime.Now;
    }
}
