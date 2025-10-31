using ITControl.Domain.Shared.Entities;

namespace ITControl.Domain.Pages.Props;

public class PageProps : Entity
{
    public string Name { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
}