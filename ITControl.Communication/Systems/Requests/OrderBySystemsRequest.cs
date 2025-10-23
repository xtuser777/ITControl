using ITControl.Domain.Systems.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Communication.Systems.Requests;

public record OrderBySystemsRequest
{
    [FromHeader(Name = "X-Order-By-Name")]
    public string? Name { get; init; }
    
    [FromHeader(Name = "X-Order-By-Version")]
    public string? Version { get; init; }
    
    [FromHeader(Name = "X-Order-By-Implemented-At")]
    public string? ImplementedAt { get; init; }
    
    [FromHeader(Name = "X-Order-By-Ended-At")]
    public string? EndedAt { get; init; }
    
    [FromHeader(Name = "X-Order-By-Own")]
    public string? Own { get; init; }

    public static implicit operator OrderBySystemsParams(
        OrderBySystemsRequest request) =>
        new()
        {
            Name = request.Name,
            Version = request.Version,
            ImplementedAt = request.ImplementedAt,
            EndedAt = request.EndedAt,
            Own = request.Own
        };
}