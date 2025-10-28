using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Pages.Params;

public record OrderByPagesParams : OrderByParams
{
    public string? Name { get; set; }
}