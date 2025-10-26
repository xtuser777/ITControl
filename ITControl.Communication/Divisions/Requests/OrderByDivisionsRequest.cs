using ITControl.Domain.Divisions.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Communication.Divisions.Requests;

public record OrderByDivisionsRequest
{
    [FromHeader(Name = "X-Order-By-Name")]
    public string? Name { get; init; } = null;
    
    [FromHeader(Name = "X-Order-By-Department")]
    public string? Department { get; init; } = null;

    public static implicit operator OrderByDivisionsParams(
        OrderByDivisionsRequest request)
        => new()
        {
            Name = request.Name,
            Department = request.Department,
        };
}