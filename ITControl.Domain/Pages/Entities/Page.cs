using ITControl.Domain.Pages.Props;

namespace ITControl.Domain.Pages.Entities;

public class Page : PageProps
{
    public Page() {}

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