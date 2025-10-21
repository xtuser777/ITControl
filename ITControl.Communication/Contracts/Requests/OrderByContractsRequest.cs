using ITControl.Domain.Contracts.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Communication.Contracts.Requests;

public record OrderByContractsRequest
{
    [FromHeader(Name = "X-Order-By-Object-Name")]
    public string? ObjectName { get; set; } = null;

    [FromHeader(Name = "X-Order-By-Started-At")]
    public string? StartedAt { get; set; } = null; 
    
    [FromHeader(Name = "X-Order-By-Ended-At")]
    public string? EndedAt { get; set; } = null;

    public static implicit operator OrderByContractsRepositoryParams(OrderByContractsRequest request)
    {
        return new OrderByContractsRepositoryParams
        {
            ObjectName = request.ObjectName,
            StartedAt = request.StartedAt,
            EndedAt = request.EndedAt
        };
    }
}
