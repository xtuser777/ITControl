using ITControl.Application.Equipments.Params;
using ITControl.Communication.Equipments.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Equipments.Params;

public record CreateEquipmentsControllerParams
{
    [FromBody]
    public CreateEquipmentsRequest Request { get; init; } = null!;

    public static implicit operator CreateEquipmentsServiceParams(CreateEquipmentsControllerParams @params)
        => new()
        {
            Params = @params.Request
        };
}