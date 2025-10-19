using ITControl.Application.Equipments.Params;
using ITControl.Communication.Equipments.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Equipments.Params;

public record UpdateEquipmentsControllerParams
{
    [FromRoute(Name = "id")] public Guid Id { get; set; }

    [FromBody] public UpdateEquipmentsRequest Request { get; set; } = null!;

    public static implicit operator UpdateEquipmentsServiceParams(UpdateEquipmentsControllerParams @params)
        => new()
        {
            Id = @params.Id,
            Params = @params.Request
        };
}