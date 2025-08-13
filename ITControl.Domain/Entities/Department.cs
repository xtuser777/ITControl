using ITControl.Domain.Validation;

namespace ITControl.Domain.Entities;

public class Department : Entity
{
    public string Alias { get; private set; }
    public string Name { get; private set; }
    public Guid UserId { get; set; }
    public User? User { get; set; }

    public Department(string alias, string name)
    {
        Alias = alias;
        Name = name;
        Validate();
    }

    public static Department Create(string alias, string name, Guid userId)
    {
        var department = new Department(alias, name)
        {
            Id = Guid.NewGuid(),
            Alias = alias,
            Name = name,    
            UserId = userId,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
        };
        
        department.Validate();
        
        return department;
    }

    public void Update(string? alias = null, string? name = null, Guid? userId = null)
    {
        Alias = alias ?? Alias;
        Name = name ?? Name;
        UserId = userId ?? UserId;
        UpdatedAt = DateTime.Now;
        
        Validate();
    }

    private void Validate()
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(Alias), "O campo sigla não pode ser vazio");
        DomainExceptionValidation.When(Alias.Length > 10, "O campo sigla deve ter 10 ou menos caracteres");
        
        DomainExceptionValidation.When(string.IsNullOrEmpty(Name), "O campo nome não pode ser vazio");
        DomainExceptionValidation.When(Name.Length > 100, "O campo nome deve ter 100 ou menos caracteres");
    }
}