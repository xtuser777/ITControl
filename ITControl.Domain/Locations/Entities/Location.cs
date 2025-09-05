using ITControl.Domain.Departments.Entities;
using ITControl.Domain.Divisions.Entities;
using ITControl.Domain.Entities;
using ITControl.Domain.Units.Entities;
using ITControl.Domain.Users.Entities;

namespace ITControl.Domain.Locations.Entities;

public sealed class Location : Entity
{
    public Location(
        string description, 
        Guid unitId, 
        Guid userId, 
        Guid departmentId, 
        Guid? divisionId)
    {
        Id = Guid.NewGuid();
        Description = description;
        UnitId = unitId;
        UserId = userId;
        DepartmentId = departmentId;
        DivisionId = divisionId;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public string Description { get; set; } = string.Empty;
    public Guid UnitId { get; set; }
    public Guid UserId { get; set; }
    public Guid DepartmentId { get; set; }
    public Guid? DivisionId { get; set; }

    public Unit? Unit { get; set; }
    public User? User { get; set; }
    public Department? Department { get; set; }
    public Division? Division { get; set; }

    public void Update(
        string? description = null, 
        Guid? unitId = null, 
        Guid? userId = null, 
        Guid? departmentId = null, 
        Guid? divisionId = null)
    {
        Description = description ?? Description;
        UnitId = unitId ?? UnitId;
        UserId = userId ?? UserId;
        DepartmentId = departmentId ?? DepartmentId;
        DivisionId = divisionId ?? DivisionId;
        UpdatedAt = DateTime.Now;
    }
}