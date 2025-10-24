using ITControl.Communication.Shared.Requests;
using ITControl.Communication.Shared.Utils;
using ITControl.Domain.Calls.Enums;
using ITControl.Domain.Calls.Params;

namespace ITControl.Communication.Calls.Requests;
public record FindManyCallsRequest : FindManyRequest
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Reason { get; set; }
    public string? Status { get; set; }
    public Guid? UserId { get; set; }

    public static implicit operator FindManyCallsParams(
        FindManyCallsRequest request) =>
        new()
        {
            Title = request.Title,
            Description = request.Description,
            Reason = Parser.ToEnumOptional<CallReason>(request.Reason),
            Status = Parser.ToEnumOptional<CallStatus>(request.Status),
            UserId = request.UserId,
        };

    public static implicit operator CountCallsParams(
        FindManyCallsRequest request) =>
        new ()
        {
            Title = request.Title,
            Description = request.Description,
            Reason = Parser.ToEnumOptional<CallReason>(request.Reason),
            Status = Parser.ToEnumOptional<CallStatus>(request.Status),
            UserId = request.UserId,
        };
}
