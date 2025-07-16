using ITControl.Domain.Validation;

namespace ITControl.Domain.Entities;

public class Page : Entity
{
    public string Name { get; private set; }

    public Page(Guid id, string name, DateTime createdAt, DateTime updatedAt)
    {
        Id = id;
        Name = name;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public static Page Create(string name)
    {
        var page = new Page(Guid.NewGuid(), name, DateTime.Now, DateTime.Now);
        page.Validate();
        
        return page;
    }

    public void Update(string? name = null)
    {
        Name = name ?? Name;
        UpdatedAt = DateTime.Now;
        
        Validate();
    }

    private void Validate()
    {
        DomainExceptionValidation.When(
            string.IsNullOrEmpty(Name), 
            "O campo nome não pode estar vazio."
        );
        DomainExceptionValidation.When(
            Name.Length > 100, 
            "O campo nome não pode conter mais que 100 caracteres."
        );
        
        DomainExceptionValidation.Throw();
    }
}