using ITControl.Communication.Systems.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Systems.Headers;

public record OrderBySystemsHeaders
{
    [FromHeader(Name = "X-Order-By-Name")]
    public string? Name { get; set; }
    
    [FromHeader(Name = "X-Order-By-Version")]
    public string? Version { get; set; }
    
    [FromHeader(Name = "X-Order-By-Implemented-At")]
    public string? ImplementedAt { get; set; }
    
    [FromHeader(Name = "X-Order-By-Ended-At")]
    public string? EndedAt { get; set; }
    
    [FromHeader(Name = "X-Order-By-Own")]
    public string? Own { get; set; }

    public static implicit operator OrderBySystemsRequest(OrderBySystemsHeaders request) =>
        new()
        {
            Name = request.Name,
            Version = request.Version,
            ImplementedAt = request.ImplementedAt,
            EndedAt = request.EndedAt,
            Own = request.Own
        };
}
