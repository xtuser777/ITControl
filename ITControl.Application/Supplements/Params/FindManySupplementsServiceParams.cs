using ITControl.Domain.Shared.Params;
using ITControl.Domain.Supplements.Params;

namespace ITControl.Application.Supplements.Params;

public record FindManySupplementsServiceParams
{
    public FindManySupplementsParams FindManyParams { get; set; } = new();
    public OrderBySupplementsParams OrderByParams { get; set; } = new();
    public PaginationParams PaginationParams { get; set; } = new();
    
    public static implicit operator FindManySupplementsRepositoryParams(
        FindManySupplementsServiceParams serviceParams)
        => new ()
        {
            FindMany = serviceParams.FindManyParams,
            OrderBy = serviceParams.OrderByParams,
            Pagination = serviceParams.PaginationParams,
        };
}