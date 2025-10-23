using ITControl.Application.Shared.Params;
using ITControl.Communication.Treatments.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Treatments.Params;

public record IndexTreatmentsParams
{
    [FromQuery] public FindManyTreatmentsRequest 
        FindManyTreatmentsRequest { get; set; } = new();
    [FromHeader] public OrderByTreatmentsRequest 
        OrderByTreatmentsRequest { get; set; } = new();

    public static implicit operator FindManyServiceParams(
        IndexTreatmentsParams parameters)
        => new()
        {
            FindManyParams = parameters.FindManyTreatmentsRequest,
            OrderByParams = parameters.OrderByTreatmentsRequest,
            PaginationParams = parameters.FindManyTreatmentsRequest,
        };

    public static implicit operator FindManyPaginationServiceParams(
        IndexTreatmentsParams parameters)
        => new()
        {
            CountParams = parameters.FindManyTreatmentsRequest,
            PaginationParams = parameters.FindManyTreatmentsRequest,
        };
}