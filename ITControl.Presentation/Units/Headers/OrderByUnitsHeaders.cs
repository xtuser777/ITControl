using ITControl.Communication.Units.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Units.Headers;

public record OrderByUnitsHeaders
{
    [FromHeader(Name = "X-Order-By-Name")]
    public string? Name { get; set; }

    public static implicit operator OrderByUnitsRequest(OrderByUnitsHeaders headers) => new()
    {
        Name = headers.Name
    };
}
