using ITControl.Application.Equipments.Params;
using ITControl.Communication.Equipments.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Equipments.Params;

public record IndexEquipmentsControllerParams
{
    [FromQuery]
    public FindManyEquipmentsRequest FindManyRequest { get; set; } = null!;

    [FromHeader]
    public OrderByEquipmentsRequest OrderByRequest { get; set; }  = null!;

    public static implicit operator FindManyEquipmentsServiceParams(
        IndexEquipmentsControllerParams @params)
    {
        var serviceParams = new FindManyEquipmentsServiceParams()
        {
            FindManyParams = @params.FindManyRequest,
            OrderByParams = @params.OrderByRequest,
            PaginationParams = @params.FindManyRequest,
        };
        
        return serviceParams;
    }

    public static implicit operator FindManyPaginationEquipmentsServiceParams(
        IndexEquipmentsControllerParams @params)
        => new()
        {
            CountParams = @params.FindManyRequest,
            Page = @params.FindManyRequest.Page,
            Size = @params.FindManyRequest.Size,
        };
}