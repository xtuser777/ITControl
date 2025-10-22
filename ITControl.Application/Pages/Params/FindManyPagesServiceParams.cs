using ITControl.Domain.Pages.Params;
using ITControl.Domain.Shared.Params;

namespace ITControl.Application.Pages.Params;

public record FindManyPagesServiceParams
{
    public FindManyPagesParams FindManyParams { get; init; } = new();
    public OrderByPagesParams OrderByParams { get; init; } = new();
    public PaginationParams PaginationParams { get; init; } = new();

    public static implicit operator FindManyPagesRepositoryParams(
        FindManyPagesServiceParams @params)
        => new()
        {
            FindMany = @params.FindManyParams,
            OrderBy = @params.OrderByParams,
            Pagination = @params.PaginationParams,
        };
}
