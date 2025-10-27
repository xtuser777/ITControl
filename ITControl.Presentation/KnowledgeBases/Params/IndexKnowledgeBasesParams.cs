using ITControl.Application.Shared.Params;
using ITControl.Domain.Calls.Enums;
using ITControl.Domain.KnowledgeBases.Params;
using ITControl.Domain.Shared.Params;
using ITControl.Domain.Shared.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.KnowledgeBases.Params;

public record IndexKnowledgeBasesParams : PaginationParams
{
    public string? Title { get; set; }
    public string? Content { get; set; }
    public TimeOnly? EstimatedTime { get; set; }
    public string? Reason { get; set; }
    public Guid? UserId { get; set; }
    
    [FromHeader(Name = "X-Order-By-Title")]
    public string? OrderByTitle { get; set; }

    [FromHeader(Name = "X-Order-By-Content")]
    public string? OrderByContent { get; set; }
    
    [FromHeader(Name = "X-Order-By-Estimated-Time")]
    public string? OrderByEstimatedTime { get; set; }
    
    [FromHeader(Name = "X-Order-By-Reason")]
    public string? OrderByReason { get; set; }
    
    [FromHeader(Name = "X-Order-By-User")]
    public string? OrderByUser { get; set; }

    public static implicit operator OrderByKnowledgeBasesParams(
        IndexKnowledgeBasesParams request) =>
        new()
        {
            Title = request.OrderByTitle,
            Content = request.OrderByContent,
            EstimatedTime = request.OrderByEstimatedTime,
            Reason = request.OrderByReason,
            User = request.OrderByUser,
        };

    public static implicit operator FindManyKnowledgeBasesParams(
        IndexKnowledgeBasesParams request) =>
        new()
        {
            Title = request.Title,
            Content = request.Content,
            EstimatedTime = request.EstimatedTime,
            Reason = Parser.ToEnumOptional<CallReason>(request.Reason),
            UserId = request.UserId,
        };

    public static implicit operator CountKnowledgeBasesParams(
        IndexKnowledgeBasesParams request) =>
        new()
        {
            Title = request.Title,
            Content = request.Content,
            EstimatedTime = request.EstimatedTime,
            Reason = Parser.ToEnumOptional<CallReason>(request.Reason),
            UserId = request.UserId
        };

    public static implicit operator FindManyServiceParams(
        IndexKnowledgeBasesParams index)
        => new()
        {
            FindManyParams = index,
            OrderByParams = index,
            PaginationParams = index,
        };

    public static implicit operator FindManyPaginationServiceParams(
        IndexKnowledgeBasesParams index)
        => new()
        {
            CountParams = index,
            PaginationParams = index,
        };
}
