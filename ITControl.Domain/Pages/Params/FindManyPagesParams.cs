using ITControl.Domain.Shared.Params2;

namespace ITControl.Domain.Pages.Params;

public record FindManyPagesParams : FindManyParams
{
    public string? Name { get; set; } = null;
}