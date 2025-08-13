using ITControl.Domain.Validation;

namespace ITControl.Domain.Entities;

public sealed class Location : Entity
{
    private string _description = string.Empty;
    private Guid _unitId;
    private Guid _userId;
    private Guid _departmentId;
    private Guid? _divisionId;

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

    public string Description
    {
        get => _description;
        set
        {
            DomainExceptionValidation.When(
                string.IsNullOrEmpty(_description),
                "Description can not be empty");
            DomainExceptionValidation.When(
                _description.Length > 100,
                "Description can not be longer than 100 characters");
            _description = value;
        }
    }

    public Guid UnitId
    {
        get => _unitId;
        set
        {
            DomainExceptionValidation.When(
                _unitId == Guid.Empty,
                "UnitId can not be empty");
            _unitId = value;
        }
    }

    public Guid UserId
    {
        get => _userId;
        set
        {
            DomainExceptionValidation.When(
                _userId == Guid.Empty,
                "UserId can not be empty");
            _userId = value;
        }
    }

    public Guid DepartmentId
    {
        get => _departmentId;
        set
        {
            DomainExceptionValidation.When(
                _departmentId == Guid.Empty,
                "DepartmentId can not be empty");
            _departmentId = value;
        }
    }

    public Guid? DivisionId
    {
        get => _divisionId;
        set
        {
            DomainExceptionValidation.When(
                _divisionId != null && _divisionId != Guid.Empty,
                "DivisionId can not be empty");
            _divisionId = value;
        }
    }

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