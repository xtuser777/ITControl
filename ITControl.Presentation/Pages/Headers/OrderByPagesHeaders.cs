using ITControl.Communication.Pages.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Pages.Headers;

public record OrderByPagesHeaders
{
    [FromHeader(Name = "X-Order-By-Name")]
    public string? Name { get; set; }

    public static implicit operator OrderByPagesRequest(OrderByPagesHeaders headers) =>
        new()
        {
            Name = headers.Name,
        };
}
