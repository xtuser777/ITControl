using ITControl.Application.Equipments.Params;
using ITControl.Domain.Equipments.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Equipments.Params;

public record ShowEquipmentsControllerParams
{
    [FromRoute(Name = "id")]
    public Guid Id { get; init; }
    
    [FromQuery]
    public bool? IncludeContract { get; init; } = true;

    public static implicit operator FindOneEquipmentsServiceParams(
        ShowEquipmentsControllerParams @params)
        => new()
        {
            Id = @params.Id,
            Includes = new IncludesEquipmentsParams
            {
                Contract = @params.IncludeContract,
            }
        };
}