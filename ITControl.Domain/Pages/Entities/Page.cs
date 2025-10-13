using ITControl.Domain.Pages.Params;
using ITControl.Domain.Shared.Entities;

namespace ITControl.Domain.Pages.Entities;

public class Page : Entity
{
    public string Name { get; set; } = string.Empty;
    
    public Page() {}

    public Page(PageParams @params)
    {
        Id = Guid.NewGuid();
        Name = @params.Name;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public void Update(UpdatePageParams @params)
    {
        Name = @params.Name ?? Name;
        UpdatedAt = DateTime.Now;
    }
}