using ITControl.Communication.Equipments.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Equipments.Headers;

public record OrderByEquipmentsHeaders
{
    [FromHeader(Name = "X-Order-By-Name")]
    public string? Name { get; set; }
    
    [FromHeader(Name = "X-Order-By-Description")]
    public string? Description { get; set; }
    
    [FromHeader(Name = "X-Order-By-Ip")]
    public string? Ip { get; set; }
    
    [FromHeader(Name = "X-Order-By-Mac")]
    public string? Mac { get; set; }
    
    [FromHeader(Name = "X-Order-By-Tag")]
    public string? Tag { get; set; }
    
    [FromHeader(Name = "X-Order-By-Type")]
    public string? Type { get; set; }
    
    [FromHeader(Name = "X-Order-By-Rented")]
    public string? Rented { get; set; }

    public static implicit operator OrderByEquipmentsRequest(OrderByEquipmentsHeaders headers) =>
        new()
        {
            Name = headers.Name,
            Description = headers.Description,
            Ip = headers.Ip,
            Mac = headers.Mac,
            Tag = headers.Tag,
            Type = headers.Type,
            Rented = headers.Rented
        };
}
