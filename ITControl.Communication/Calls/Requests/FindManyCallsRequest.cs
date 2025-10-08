using ITControl.Communication.Shared.Requests;
using ITControl.Domain.Calls.Params;

namespace ITControl.Communication.Calls.Requests;
public class FindManyCallsRequest : PageableRequest
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Reason { get; set; }
    public string? Status { get; set; }
    public Guid? UserId { get; set; }
    public string? OrderByTitle { get; set; }
    public string? OrderByDescription { get; set; }
    public string? OrderByReason { get; set; }
    public string? OrderByStatus { get; set; }
    public string? OrderByUser { get; set; }

    public static implicit operator FindManyCallsRepositoryParams(FindManyCallsRequest request) =>
        new()
        {
            Title = request.Title,
            Description = request.Description,
            Reason = Enum.TryParse<Domain.Calls.Enums.CallReason>(request.Reason, true, out var reason) ? reason : null,
            Status = Enum.TryParse<Domain.Calls.Enums.CallStatus>(request.Status, true, out var status) ? status : null,
            UserId = request.UserId,
            OrderByTitle = request.OrderByTitle,
            OrderByDescription = request.OrderByDescription,
            OrderByReason = request.OrderByReason,
            OrderByStatus = request.OrderByStatus,
            OrderByUser = request.OrderByUser,
            Page = string.IsNullOrEmpty(request.Page) ? null : int.Parse(request.Page),
            Size = string.IsNullOrEmpty(request.Size) ? null : int.Parse(request.Size)
        };

    public static implicit operator CountCallsRepositoryParams(FindManyCallsRequest request) =>
        (FindManyCallsRepositoryParams)request;
}
