using ITControl.Application.Equipments.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Equipments.Params;

public record DeleteEquipmentsControllerParams
{
    [FromRoute(Name = "id")]
    public Guid Id { get; init; }

    public static implicit operator DeleteEquipmentsServiceParams(DeleteEquipmentsControllerParams @params)
        => new()
        {
            Id = @params.Id,
        };
}