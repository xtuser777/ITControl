using ITControl.Domain.Validation;

namespace ITControl.Domain.Entities;

public sealed class Role : Entity
{
    private string _name = string.Empty;
    private bool _active;

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
                .When(value.Length > 64)
                .Property("Name")
                .LengthMustBeLessThanOrEqualTo(64);
            _name = value;
        } 
    }
    public bool Active 
    { 
        get => _active; 
        set
        {
            DomainExceptionValidation
                .When(CreatedAt == UpdatedAt && value == false)
                .Property("Active")
                .MustBeTrue();
            _active = value;
        } 
    }

    public ICollection<RolePage>? RolesPages { get; set; }

    public Role(string name, bool active)
    {
        Id = Guid.NewGuid();
        Name = name;
        Active = active;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public void Update(string? name = null, bool? active = null)
    {
        Name = name ?? Name;
        Active = active ?? Active;
        UpdatedAt = DateTime.Now;
    }
}