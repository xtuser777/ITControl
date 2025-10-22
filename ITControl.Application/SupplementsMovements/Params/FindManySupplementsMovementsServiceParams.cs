using ITControl.Domain.Shared.Params;
using ITControl.Domain.SupplementsMovements.Params;

namespace ITControl.Application.SupplementsMovements.Params;

public record FindManySupplementsMovementsServiceParams
{
    public FindManySupplementsMovementsParams 
        FindManySupplementsMovementsParams { get; set; } = new();

    public OrderBySupplementsMovementsParams 
        OrderBySupplementsMovementsParams { get; set; } = new();

    public PaginationParams PaginationParams { get; set; } = new();

    public static implicit operator FindManySupplementsMovementsRepositoryParams(
        FindManySupplementsMovementsServiceParams param)
        => new()
        {
            FindMany = param.FindManySupplementsMovementsParams,
            OrderBy = param.OrderBySupplementsMovementsParams,
            Pagination = param.PaginationParams,
        };
}