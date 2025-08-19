using ITControl.Domain.Validation;

namespace ITControl.Domain.Entities;

public sealed class Position : Entity
{
    private string _description = string.Empty;

    public Position(string description)
    {
        Id = Guid.NewGuid();
        Description = description;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }
    
    public string Description 
    { 
        get => _description; 
        set
        {
            DomainExceptionValidation
                .When(string.IsNullOrEmpty(value))
                .Property("Description")
                .MustNotBeEmpty();
            DomainExceptionValidation
                .When(value.Length > 100)
                .Property("Description")
                .LengthMustBeLessThanOrEqualTo(100);
            _description = value;
        } 
    }

    public void Update(string? description)
    {
        Description = description ?? Description;
        UpdatedAt = DateTime.Now;
    }
}