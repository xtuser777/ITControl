using ITControl.Domain.Shared.Params;
using FindManyRepositoryParams = ITControl.Domain.Shared.Params.FindManyRepositoryParams;

namespace ITControl.Application.Shared.Params;

public record FindManyServiceParams
{
    public FindManyParams FindManyParams { get; set; } = new();
    public OrderByParams OrderByParams { get; set; }  = new();
    public PaginationParams PaginationParams { get; set; }  = new();

    public static implicit operator FindManyRepositoryParams(
        FindManyServiceParams parameters)
        => new()
        {
            FindMany = parameters.FindManyParams,
            OrderBy = parameters.OrderByParams,
            Pagination = parameters.PaginationParams,
        };
}