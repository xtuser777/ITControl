using ITControl.Domain.Shared.Params;
using ITControl.Domain.Systems.Params;

namespace ITControl.Application.Systems.Params;

public record FindManySystemsServiceParams
{
    public FindManySystemsParams FindManySystemsParams { get; set; } = new();
    public OrderBySystemsParams OrderBySystemsParams { get; set; }  = new();
    public PaginationParams PaginationParams { get; set; }  = new();

    public static implicit operator FindManySystemsRepositoryParams(
        FindManySystemsServiceParams serviceParams)
        => new()
        {
            FindMany = serviceParams.FindManySystemsParams,
            OrderBy = serviceParams.OrderBySystemsParams,
            Pagination = serviceParams.PaginationParams,
        };
}