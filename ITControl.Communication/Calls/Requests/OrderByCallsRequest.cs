using ITControl.Domain.Calls.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Communication.Calls.Requests;

public record OrderByCallsRequest
{
    [FromHeader(Name = "X-Order-By-Title")]
    public string? Title { get; set; } = null;
    [FromHeader(Name = "X-Order-By-Description")]
    public string? Description { get; set; } = null;
    [FromHeader(Name = "X-Order-By-Reason")]
    public string? Reason { get; set; } = null;
    [FromHeader(Name = "X-Order-By-Status")]
    public string? Status { get; set; } = null;
    [FromHeader(Name = "X-Order-By-User")]
    public string? User { get; set; } = null;

    public static implicit operator OrderByCallsRepositoryParams(
        OrderByCallsRequest request) =>
        new ()
        {
            Title = request.Title,
            Description = request.Description,
            Reason = request.Reason,
            Status = request.Status,
            User = request.User,
        };
}