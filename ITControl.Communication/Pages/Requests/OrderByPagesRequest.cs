using ITControl.Domain.Pages.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Communication.Pages.Requests;

public record OrderByPagesRequest
{
    [FromHeader(Name = "X-Order-By-Name")]
    public string? Name { get; set; }

    public static implicit operator OrderByPagesRepositoryParams(OrderByPagesRequest request) => 
        new() 
        { 
            Name = request.Name, 
        };
}