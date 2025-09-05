using ITControl.Domain.Entities;

namespace ITControl.Domain.Pages.Entities;

public class Page : Entity
{
    public string Name { get; set; } = string.Empty;

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