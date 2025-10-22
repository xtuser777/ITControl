using ITControl.Domain.Supplements.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Communication.Supplements.Requests;

public record OrderBySupplementsRequest
{
    [FromHeader(Name = "X-Order-By-Brand")]
    public string? Brand { get; set; } = null!;
    
    [FromHeader(Name = "X-Order-By-Model")]
    public string? Model { get; set; } = null!;
    
    [FromHeader(Name = "X-Order-By-Type")]
    public string? Type { get; set; } = null!;
    
    [FromHeader(Name = "X-Order-By-Stock")]
    public string? Stock { get; set; }

    public static implicit operator OrderBySupplementsParams(
        OrderBySupplementsRequest request)
        => new()
        {
            Brand = request.Brand,
            Model = request.Model,
            Type = request.Type,
            Stock = request.Stock,
        };
}
