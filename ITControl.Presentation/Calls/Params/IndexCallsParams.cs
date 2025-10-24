using ITControl.Application.Shared.Params;
using ITControl.Communication.Calls.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Calls.Params;

public record IndexCallsParams
{
    [FromQuery]
    public FindManyCallsRequest FindManyRequest { get; set; } = new();
    [FromHeader]
    public OrderByCallsRequest OrderByRequest { get; set; } = new();

    public static implicit operator FindManyServiceParams(
        IndexCallsParams indexCallsParams)
        => new ()
        {
            FindManyParams = indexCallsParams.FindManyRequest,
            OrderByParams = indexCallsParams.OrderByRequest,
            PaginationParams = indexCallsParams.FindManyRequest
        };

    public static implicit operator FindManyPaginationServiceParams(
        IndexCallsParams indexCallsParams)
        => new ()
        {
            CountParams = indexCallsParams.FindManyRequest,
            PaginationParams = indexCallsParams.FindManyRequest
        };
}