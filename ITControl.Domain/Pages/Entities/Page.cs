using ITControl.Domain.Shared.Entities;

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

    public void Update(UpdatePageParams @params)
    {
        Name = @params.Name ?? Name;
        UpdatedAt = DateTime.Now;
    }
}

public class UpdatePageParams
{
    public string? Name { get; set; }
}