using ITControl.Application.Calls.Params;
using ITControl.Communication.Calls.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Calls.Params;

public record IndexCallsParams
{
    [FromQuery]
    public FindManyCallsRequest FindManyRequest { get; set; } = new();
    [FromHeader]
    public OrderByCallsRequest OrderByRequest { get; set; } = new();

    public static implicit operator FindManyCallsServiceParams(IndexCallsParams indexCallsParams)
        => new FindManyCallsServiceParams
        {
            FindManyParams = indexCallsParams.FindManyRequest,
            OrderByParams = indexCallsParams.OrderByRequest,
            PaginationParams = indexCallsParams.FindManyRequest
        };

    public static implicit operator FindManyPaginationCallsServiceParams(IndexCallsParams indexCallsParams)
        => new FindManyPaginationCallsServiceParams
        {
            CountParams = indexCallsParams.FindManyRequest,
            Page = indexCallsParams.FindManyRequest.Page,
            Size = indexCallsParams.FindManyRequest.Size
        };
}