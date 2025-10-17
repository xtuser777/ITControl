using ITControl.Domain.Positions.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Communication.Positions.Requests;

public record OrderByPositionsRequest
{
    [FromHeader(Name = "X-Order-By-Name")]
    public string? Name { get; set; } = null;

    public static implicit operator OrderByPositionsRepositoryParams(OrderByPositionsRequest request) =>
        new()
        {
            Name = request.Name, 
        };
}