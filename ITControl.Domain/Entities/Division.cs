using ITControl.Domain.Validation;

namespace ITControl.Domain.Entities;

public class Division : Entity
{
    public string Name { get; private set; }

    public Guid DepartmentId { get; set; }
    public Department? Department { get; set; }

    public Guid UserId { get; set; }
    public User? User { get; set; }

    public Division(string name)
    {
        Name = name;
        
        Validate();
    }

    public static Division Create(string name, Guid departmentId, Guid userId)
    {
        var division = new Division(name)
        {
            Id = Guid.NewGuid(),
            DepartmentId = departmentId,
            UserId = userId,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
        };
        
        division.Validate();
        
        return division;
    }

    public void Update(string? name = null, Guid? departmentId = null, Guid? userId = null)
    {
        Name = name ?? Name;
        DepartmentId = departmentId ?? DepartmentId;
        UserId = userId ?? UserId;
        UpdatedAt = DateTime.Now;
        
        Validate();
    }

    private void Validate()
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(Name), "o campo nome não pode ser vazio");
        DomainExceptionValidation.When(Name.Length > 100, "O campo nome conter 100 ou menos caracteres");
        
        DomainExceptionValidation.Throw();
    }
}