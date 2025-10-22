using ITControl.Domain.Shared.Params2;

namespace ITControl.Domain.Pages.Params;

public record OrderByPagesParams : OrderByParams
{
    public string? Name { get; set; } = null;
}