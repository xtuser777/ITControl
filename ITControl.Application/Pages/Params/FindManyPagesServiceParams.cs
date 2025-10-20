using ITControl.Domain.Pages.Params;
using ITControl.Domain.Shared.Params;

namespace ITControl.Application.Pages.Params;

public record FindManyPagesServiceParams
{
    public FindManyPagesRepositoryParams FindManyParams { get; set; } = new();
    public OrderByPagesRepositoryParams OrderByParams { get; set; } = new();
    public PaginationParams PaginationParams { get; set; } = new();
}
