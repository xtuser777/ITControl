using ITControl.Domain.Validation;

namespace ITControl.Domain.Entities;

public class Department : Entity
{
    private string _alias = string.Empty;
    private string _name = string.Empty;
    private Guid _userId;

    public string Alias 
    { 
        get => _alias; 
        set
        {
            DomainExceptionValidation
                .When(string.IsNullOrEmpty(value))
                .Property("Alias")
                .MustNotBeEmpty();
            DomainExceptionValidation
                .When(value.Length > 10)
                .Property("Alias")
                .LengthMustBeLessThanOrEqualTo(10);
            _alias = value;
        } 
    }
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
    public User? User { get; set; }

    public Department(string alias, string name, Guid userId)
    {
        Id = Guid.NewGuid();
        Alias = alias;
        Name = name;
        UserId = userId;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public void Update(string? alias = null, string? name = null, Guid? userId = null)
    {
        Alias = alias ?? Alias;
        Name = name ?? Name;
        UserId = userId ?? UserId;
        UpdatedAt = DateTime.Now;
    }
}