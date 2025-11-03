using ITControl.Application.Shared.Params;
using ITControl.Presentation.Equipments.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Equipments.Params;

public record UpdateEquipmentsParams
{
    [FromRoute(Name = "id")] 
    public Guid Id { get; set; }

    [FromBody] 
    public UpdateEquipmentsRequest Request { get; set; } = new();

    public static implicit operator UpdateServiceParams(
        UpdateEquipmentsParams @params)
        => new()
        {
            Id = @params.Id,
            Props= @params.Request
        };
}