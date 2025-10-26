using ITControl.Application.Shared.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Equipments.Params;

public record DeleteEquipmentsParams
{
    [FromRoute(Name = "id")]
    public Guid Id { get; init; }

    public static implicit operator DeleteServiceParams(
        DeleteEquipmentsParams @params)
        => new()
        {
            Id = @params.Id,
        };
}