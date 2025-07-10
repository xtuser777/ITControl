using ITControl.Domain.Validation;

namespace ITControl.Domain.Entities;

public sealed class Position : Entity
{
    public Position(Guid id, string description, DateTime createdAt, DateTime updatedAt)
    {
        Id = id;
        Description = description;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }
    
    public static Position Create(string description)
    {
        var position = new Position(
            id: Guid.NewGuid(),
            description: description,
            createdAt: DateTime.UtcNow,
            updatedAt: DateTime.UtcNow
        );
        
        position.Validate();
        
        return position;
    }
    
    public string Description { get; private set; }

    public void Update(string? description)
    {
        Description = description ?? Description;
        
        Validate();
    }

    private void Validate()
    {
        DomainExceptionValidation.When(
            string.IsNullOrEmpty(Description), 
            "O campo descrição não pode estar vazio."
        );
        DomainExceptionValidation.When(
            Description.Length > 100, 
            "O campo descrição não pode conter mais que 100 caracteres."
        );
        
        DomainExceptionValidation.Throw();
    }
}