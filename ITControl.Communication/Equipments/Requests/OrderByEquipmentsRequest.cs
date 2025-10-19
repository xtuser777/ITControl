using ITControl.Domain.Equipments.Params;
using ITControl.Domain.Shared.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Communication.Equipments.Requests;

public record OrderByEquipmentsRequest
{
    [FromHeader(Name = "X-Order-By-Name")]
    public string? Name { get; init; } = null;
    
    [FromHeader(Name = "X-Order-By-Description")]
    public string? Description { get; init; } = null;
    
    [FromHeader(Name = "X-Order-By-Ip")]
    public string? Ip { get; init; } = null;
    
    [FromHeader(Name = "X-Order-By-Mac")]
    public string? Mac { get; init; } = null;
    
    [FromHeader(Name = "X-Order-By-Tag")]
    public string? Tag { get; init; } = null;
    
    [FromHeader(Name = "X-Order-By-Type")]
    public string? Type { get; init; } = null;
    
    [FromHeader(Name = "X-Order-By-Rented")]
    public string? Rented { get; init; } = null;

    public static implicit operator OrderByEquipmentsRepositoryParams(OrderByEquipmentsRequest request) =>
        new()
        {
            Name = request.Name,
            Description = request.Description,
            Ip = request.Ip,
            Mac = request.Mac,
            Tag = request.Tag,
            Type = request.Type,
            Rented = request.Rented
        };
}