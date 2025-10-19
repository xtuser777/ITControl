using ITControl.Domain.Equipments.Params;
using ITControl.Domain.Shared.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Communication.Equipments.Requests;

public record FindOneEquipmentsRequest
{
    [FromRoute(Name = "id")]
    public Guid Id { get; set; }
    
    [FromQuery]
    public bool? IncludeContract { get; set; } = true;

    public static implicit operator FindOneRepositoryParams(FindOneEquipmentsRequest request)
        => new()
        {
            Id = request.Id,
            Includes = new IncludesEquipmentsParams
            {
                Contract = request.IncludeContract,
            }
        };
}
