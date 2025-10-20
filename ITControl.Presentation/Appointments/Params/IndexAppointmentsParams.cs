using ITControl.Application.Appointments.Params;
using ITControl.Communication.Appointments.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Appointments.Params;

public record IndexAppointmentsParams
{
    [FromQuery]
    public FindManyAppointmentsRequest FindManyRequest { get; set; } = new();
    [FromHeader]
    public OrderByAppointmentsRequest OrderByRequest { get; set; } = new();

    public static implicit operator FindManyAppointmentsServiceParams(
        IndexAppointmentsParams indexParams) =>
        new()
        {
            FindManyParams = indexParams.FindManyRequest,
            OrderByParams = indexParams.OrderByRequest,
            PaginationParams = indexParams.FindManyRequest
        };

    public static implicit operator FindManyPaginationAppointmentsServiceParams(
        IndexAppointmentsParams indexParams) =>
        new()
        {
            CountParams = indexParams.FindManyRequest,
            Page = indexParams.FindManyRequest.Page,
            Size = indexParams.FindManyRequest.Size
        };
}
