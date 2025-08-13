using ITControl.Domain.Validation;

namespace ITControl.Domain.Entities;

public sealed class Role(string name, bool active) : Entity
{
    public string Name { get; private set; } = name;
    public bool Active { get; private set; } = active;

    public IEnumerable<RolePage>? RolesPages { get; set; } 

    public static Role Create(string name, bool active)
    {
        var role = new Role(name, active)
        {
            Id = Guid.NewGuid(),
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
        
        return role;
    }

    public void Update(string? name = null, bool? active = null)
    {
        Name = name ?? Name;
        Active = active ?? Active;
        
        UpdatedAt = DateTime.Now;
    }

    private void Validate()
    {
        DomainExceptionValidation.When(
            string.IsNullOrEmpty(Name),
            "O campo nome não pode estar vazio.");
        DomainExceptionValidation.When(
            Name.Length > 64,
            "O campo nome deve conter 64 ou menos caracteres.");
        
        DomainExceptionValidation.Throw();
    }
}