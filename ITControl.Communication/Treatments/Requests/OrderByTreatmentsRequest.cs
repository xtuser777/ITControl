using ITControl.Domain.Treatments.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Communication.Treatments.Requests;

public record OrderByTreatmentsRequest
{
    [FromHeader(Name = "X-Order-By-Description")]
    public string? Description { get; set; }
    [FromHeader(Name = "X-Order-By-Protocol")	]
    public string? Protocol { get; set; }
    [FromHeader(Name = "X-Order-By-Started-At")	]
    public string? StartedAt { get; set; }
    [FromHeader(Name = "X-Order-By-Ended-At")	]
    public string? EndedAt { get; set; }
    [FromHeader(Name = "X-Order-By-Started-In")	]
    public string? StartedIn { get; set; }
    [FromHeader(Name = "X-Order-By-Ended-In")	]
    public string? EndedIn { get; set; }
    [FromHeader(Name = "X-Order-By-Status")	]
    public string? Status { get; set; }
    [FromHeader(Name = "X-Order-By-Type")	]
    public string? Type{ get; set; }
    [FromHeader(Name = "X-Order-By-Observation")	]
    public string? Observation { get; set; }
    [FromHeader(Name = "X-Order-By-External-Protocol")	]
    public string? ExternalProtocol { get; set; }
    [FromHeader(Name = "X-Order-By-Call")	]
    public string? Call{ get; set; }
    [FromHeader(Name = "X-Order-By-User")	]
    public string? User{ get; set; }

    public static implicit operator OrderByTreatmentsParams(
        OrderByTreatmentsRequest request)
        => new()
        {
            Description = request.Description,
            Protocol = request.Protocol,
            StartedAt = request.StartedAt,
            EndedAt = request.EndedAt,
            StartedIn = request.StartedIn,
            EndedIn = request.EndedIn,
            Status = request.Status,
            Type = request.Type,
            Observation = request.Observation,
            ExternalProtocol = request.ExternalProtocol,
            Call = request.Call,
            User = request.User,
        };
}