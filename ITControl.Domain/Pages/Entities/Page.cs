using ITControl.Domain.Pages.Props;

namespace ITControl.Domain.Pages.Entities;

public class Page : PageProps
{
    public Page() 
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public Page(PageProps props)
    {
        Assign(props);
    }

    public void Update(PageProps props)
    {
        Name = props.Name;
        UpdatedAt = DateTime.Now;
    }
}