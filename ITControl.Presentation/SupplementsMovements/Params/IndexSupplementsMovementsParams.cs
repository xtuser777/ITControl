using ITControl.Application.SupplementsMovements.Params;
using ITControl.Communication.SupplementsMovements.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.SupplementsMovements.Params;

public record IndexSupplementsMovementsParams
{
    [FromQuery]
    public FindManySupplementsMovementsRequest 
        FindManySupplementsMovementsRequest { get; set; } = new();
    [FromHeader]
    public OrderBySupplementsMovementsRequest
        OrderBySupplementsMovementsRequest { get; set; } = new();

    public static implicit operator FindManySupplementsMovementsServiceParams(
        IndexSupplementsMovementsParams indexParams)
        => new()
        {
            FindManySupplementsMovementsParams = 
                indexParams.FindManySupplementsMovementsRequest,
            OrderBySupplementsMovementsParams = 
                indexParams.OrderBySupplementsMovementsRequest,
            PaginationParams = 
                indexParams.FindManySupplementsMovementsRequest,
        };

    public static implicit operator FindManyPaginationSupplementsMovementsServiceParams(
        IndexSupplementsMovementsParams indexParams)
        => new()
        {
            CountSupplementsMovementsRepositoryParams = 
                indexParams.FindManySupplementsMovementsRequest,
            Page = indexParams.FindManySupplementsMovementsRequest.Page,
            Size = indexParams.FindManySupplementsMovementsRequest.Size,
        };
}