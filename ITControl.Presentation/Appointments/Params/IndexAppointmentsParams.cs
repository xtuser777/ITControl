using ITControl.Application.Shared.Params;
using ITControl.Communication.Appointments.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Appointments.Params;

public record IndexAppointmentsParams
{
    [FromQuery]
    public FindManyAppointmentsRequest FindManyRequest { get; set; } = new();
    [FromHeader]
    public OrderByAppointmentsRequest OrderByRequest { get; set; } = new();

    public static implicit operator FindManyServiceParams(
        IndexAppointmentsParams indexParams) =>
        new()
        {
            FindManyParams = indexParams.FindManyRequest,
            OrderByParams = indexParams.OrderByRequest,
            PaginationParams = indexParams.FindManyRequest
        };

    public static implicit operator FindManyPaginationServiceParams(
        IndexAppointmentsParams indexParams) =>
        new()
        {
            CountParams = indexParams.FindManyRequest,
            PaginationParams = indexParams.FindManyRequest
        };
}
