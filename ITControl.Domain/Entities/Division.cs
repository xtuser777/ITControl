using ITControl.Domain.Validation;

namespace ITControl.Domain.Entities;

public class Division : Entity
{
    private string _name = string.Empty;
    private Guid _departmentId;
    private Guid _userId;

    public string Name 
    { 
        get => _name; 
        set 
        {
            DomainExceptionValidation
                .When(string.IsNullOrEmpty(value))
                .Property("Name")
                .MustNotBeEmpty();
            DomainExceptionValidation
                .When(value.Length > 100)
                .Property("Name")
                .LengthMustBeLessThanOrEqualTo(100);
            _name = value;
        } 
    }
    public Guid DepartmentId 
    { 
        get => _departmentId;
        set
        {
            DomainExceptionValidation
                .When(value == Guid.Empty)
                .Property("DepartmentId")
                .MustNotBeEmpty();
            DomainExceptionValidation
                .When(value == default)
                .Property("DepartmentId")
                .MustNotBeNull();
            DomainExceptionValidation
                .When(!Guid.TryParse(value.ToString(), out _))
                .Property("DepartmentId")
                .MustBeAUuid();
            _departmentId = value;
        } 
    }
    public Guid UserId 
    { 
        get => _userId; 
        set
        {
            DomainExceptionValidation
                .When(value == Guid.Empty)
                .Property("UserId")
                .MustNotBeEmpty();
            DomainExceptionValidation
                .When(value == default)
                .Property("UserId")
                .MustNotBeNull();
            DomainExceptionValidation
                .When(!Guid.TryParse(value.ToString(), out _))
                .Property("UserId")
                .MustBeAUuid();
            _userId = value;
        }
    }

    public Department? Department { get; set; }
    public User? User { get; set; }

    public Division(string name, Guid departmentId, Guid userId)
    {
        Id = Guid.NewGuid();
        Name = name;
        UserId = userId;
        DepartmentId = departmentId;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public void Update(string? name = null, Guid? departmentId = null, Guid? userId = null)
    {
        Name = name ?? Name;
        DepartmentId = departmentId ?? DepartmentId;
        UserId = userId ?? UserId;
        UpdatedAt = DateTime.Now;
    }
}