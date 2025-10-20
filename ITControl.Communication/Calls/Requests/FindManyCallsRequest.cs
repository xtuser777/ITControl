using ITControl.Communication.Shared.Requests;
using ITControl.Communication.Shared.Utils;
using ITControl.Domain.Calls.Enums;
using ITControl.Domain.Calls.Params;
using ITControl.Domain.Shared.Params;

namespace ITControl.Communication.Calls.Requests;
public record FindManyCallsRequest : PageableRequest
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Reason { get; set; }
    public string? Status { get; set; }
    public Guid? UserId { get; set; }

    public static implicit operator FindManyCallsRepositoryParams(FindManyCallsRequest request) =>
        new()
        {
            Title = request.Title,
            Description = request.Description,
            Reason = Parser.ToEnumOptional<CallReason>(request.Reason),
            Status = Parser.ToEnumOptional<CallStatus>(request.Status),
            UserId = request.UserId,
        };

    public static implicit operator CountCallsRepositoryParams(FindManyCallsRequest request) =>
        new ()
        {
            Title = request.Title,
            Description = request.Description,
            Reason = Parser.ToEnumOptional<CallReason>(request.Reason),
            Status = Parser.ToEnumOptional<CallStatus>(request.Status),
            UserId = request.UserId,
        };

    public static implicit operator PaginationParams(FindManyCallsRequest request) =>
        new ()
        {
            Page = Parser.ToIntOptional(request.Page),
            Size = Parser.ToIntOptional(request.Size),
        };
}
