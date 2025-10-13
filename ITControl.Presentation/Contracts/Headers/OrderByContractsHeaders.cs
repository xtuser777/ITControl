using ITControl.Communication.Contracts.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Contracts.Headers;

public class OrderByContractsHeaders
{
    [FromHeader(Name = "X-Order-By-Object-Name")]
    public string? ObjectName { get; set; } = null;
    [FromHeader(Name = "X-Order-By-Started-At")]
    public string? StartedAt { get; set; } = null; // "asc" | "desc"
    [FromHeader(Name = "X-Order-By-Ended-At")]
    public string? EndedAt { get; set; } = null;

    public static implicit operator OrderByContractsRequest(OrderByContractsHeaders @params)
    {
        return new OrderByContractsRequest
        {
            ObjectName = @params.ObjectName,
            StartedAt = @params.StartedAt,
            EndedAt = @params.EndedAt
        };
    }
}
