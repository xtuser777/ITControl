using ITControl.Communication.Shared.Requests;
using ITControl.Domain.Calls.Enums;
using ITControl.Domain.Shared.Utils;
using ITControl.Infrastructure.KnowledgeBases.Repositories;

namespace ITControl.Communication.KnowledgeBases.Requests;

public record FindManyKnowledgeBasesRequest : PageableRequest
{
    public string? Title { get; set; }
    public string? Content { get; set; }
    public TimeOnly? EstimatedTime { get; set; }
    public string? Reason { get; set; }
    public Guid? UserId { get; set; }
    public string? OrderByTitle { get; set; }
    public string? OrderByContent { get; set; }
    public string? OrderByEstimatedTime { get; set; }
    public string? OrderByReason { get; set; }
    public string? OrderByUser { get; set; }

    public static implicit operator FindManyKnowledgeBasesRepositoryParams(FindManyKnowledgeBasesRequest request) =>
        new()
        {
            Title = request.Title,
            Content = request.Content,
            EstimatedTime = request.EstimatedTime,
            Reason = Parser.ToEnumOptional<CallReason>(request.Reason),
            UserId = request.UserId,
            OrderByTitle = request.OrderByTitle,
            OrderByContent = request.OrderByContent,
            OrderByEstimatedTime = request.OrderByEstimatedTime,
            OrderByReason = request.OrderByReason,
            OrderByUser = request.OrderByUser,
            Page = Parser.ToIntOptional(request.Page),
            Size = Parser.ToIntOptional(request.Size)
        };

    public static implicit operator CountKnowledgeBasesRepositoryParams(FindManyKnowledgeBasesRequest request) =>
        new()
        {
            Title = request.Title,
            Content = request.Content,
            EstimatedTime = request.EstimatedTime,
            Reason = Parser.ToEnumOptional<CallReason>(request.Reason),
            UserId = request.UserId
        };

    public static implicit operator ExistsKnowledgeBasesRepositoryParams(FindManyKnowledgeBasesRequest request) =>
        new()
        {
            Title = request.Title,
            Content = request.Content,
            EstimatedTime = request.EstimatedTime,
            Reason = Parser.ToEnumOptional<CallReason>(request.Reason),
            UserId = request.UserId
        };
}
