using ITControl.Application.Shared.Params;
using ITControl.Communication.Contracts.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Contracts.Params;

public record IndexContractsParams
{
    [FromQuery]
    public FindManyContractsRequest FindManyRequest { get; set; } = new();

    [FromHeader]
    public OrderByContractsRequest OrderByRequest { get; set; } = new();

    public static implicit operator FindManyServiceParams(
        IndexContractsParams index)
        => new()
        {
            FindManyParams = index.FindManyRequest,
            OrderByParams = index.OrderByRequest,
            PaginationParams = index.FindManyRequest,
        };

    public static implicit operator FindManyPaginationServiceParams(
        IndexContractsParams index)
        => new()
        {
            CountParams = index.FindManyRequest,
            PaginationParams = index.FindManyRequest,
        };
}
