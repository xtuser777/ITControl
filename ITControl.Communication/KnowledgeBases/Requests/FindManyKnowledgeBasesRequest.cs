using ITControl.Communication.Shared.Requests;
using ITControl.Communication.Shared.Utils;
using ITControl.Domain.Calls.Enums;
using ITControl.Domain.KnowledgeBases.Params;
using ITControl.Domain.Shared.Params;

namespace ITControl.Communication.KnowledgeBases.Requests;

public record FindManyKnowledgeBasesRequest : PageableRequest
{
    public string? Title { get; set; }
    public string? Content { get; set; }
    public TimeOnly? EstimatedTime { get; set; }
    public string? Reason { get; set; }
    public Guid? UserId { get; set; }

    public static implicit operator FindManyKnowledgeBasesRepositoryParams(
        FindManyKnowledgeBasesRequest request) =>
        new()
        {
            Title = request.Title,
            Content = request.Content,
            EstimatedTime = request.EstimatedTime,
            Reason = Parser.ToEnumOptional<CallReason>(request.Reason),
            UserId = request.UserId,
        };

    public static implicit operator CountKnowledgeBasesRepositoryParams(
        FindManyKnowledgeBasesRequest request) =>
        new()
        {
            Title = request.Title,
            Content = request.Content,
            EstimatedTime = request.EstimatedTime,
            Reason = Parser.ToEnumOptional<CallReason>(request.Reason),
            UserId = request.UserId
        };

    public static implicit operator PaginationParams(
        FindManyKnowledgeBasesRequest request) =>
        new()
        {
            Page = Parser.ToIntOptional(request.Page),
            Size = Parser.ToIntOptional(request.Size)
        };
}
