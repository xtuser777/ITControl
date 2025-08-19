using ITControl.Domain.Validation;

namespace ITControl.Domain.Entities;

public class Page : Entity
{
    private string _name = string.Empty;

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

    public Page(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public void Update(string? name = null)
    {
        Name = name ?? Name;
        UpdatedAt = DateTime.Now;
    }
}