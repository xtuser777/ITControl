using ITControl.Domain.Units.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Communication.Units.Requests;

public record OrderByUnitsRequest
{
    [FromHeader(Name = "X-Order-By-Name")]
    public string? Name { get; init; }

    public static implicit operator OrderByUnitsParams(
        OrderByUnitsRequest request) => new()
    {
        Name = request.Name
    };
}