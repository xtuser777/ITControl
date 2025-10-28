using ITControl.Application.Shared.Params;
using ITControl.Presentation.Equipments.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Equipments.Params;

public record CreateEquipmentsParams
{
    [FromBody]
    public CreateEquipmentsRequest Request { get; init; } = new();

    public static implicit operator CreateServiceParams(
        CreateEquipmentsParams @params)
        => new()
        {
            Params = @params.Request
        };
}