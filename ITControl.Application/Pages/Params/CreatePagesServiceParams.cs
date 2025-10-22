using ITControl.Domain.Pages.Params;

namespace ITControl.Application.Pages.Params;

public record CreatePagesServiceParams
{
    public PageParams Params { get; init; } = new();
}
