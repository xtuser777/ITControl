using ITControl.Application.Shared.Params;
using ITControl.Domain.Calls.Enums;
using ITControl.Domain.Calls.Params;
using ITControl.Domain.Shared.Params;
using ITControl.Domain.Shared.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Calls.Params;

public record IndexCallsParams : PaginationParams
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Reason { get; set; }
    public string? Status { get; set; }
    public Guid? UserId { get; set; }
    
    [FromHeader(Name = "X-Order-By-Title")]
    public string? OrderByTitle { get; set; } = null;
    [FromHeader(Name = "X-Order-By-Description")]
    public string? OrderByDescription { get; set; } = null;
    [FromHeader(Name = "X-Order-By-Reason")]
    public string? OrderByReason { get; set; } = null;
    [FromHeader(Name = "X-Order-By-Status")]
    public string? OrderByStatus { get; set; } = null;
    [FromHeader(Name = "X-Order-By-User")]
    public string? OrderByUser { get; set; } = null;

    public static implicit operator OrderByCallsParams(
        IndexCallsParams request) =>
        new ()
        {
            Title = request.OrderByTitle,
            Description = request.OrderByDescription,
            Reason = request.OrderByReason,
            Status = request.OrderByStatus,
            User = request.OrderByUser,
        };

    public static implicit operator FindManyCallsParams(
        IndexCallsParams request) =>
        new()
        {
            Title = request.Title,
            Description = request.Description,
            Reason = Parser.ToEnumOptional<CallReason>(request.Reason),
            Status = Parser.ToEnumOptional<CallStatus>(request.Status),
            UserId = request.UserId,
        };

    public static implicit operator CountCallsParams(
        IndexCallsParams request) =>
        new ()
        {
            Title = request.Title,
            Description = request.Description,
            Reason = Parser.ToEnumOptional<CallReason>(request.Reason),
            Status = Parser.ToEnumOptional<CallStatus>(request.Status),
            UserId = request.UserId,
        };

    public static implicit operator FindManyServiceParams(
        IndexCallsParams indexCallsParams)
        => new ()
        {
            FindManyParams = indexCallsParams,
            OrderByParams = indexCallsParams,
            PaginationParams = indexCallsParams
        };

    public static implicit operator FindManyPaginationServiceParams(
        IndexCallsParams indexCallsParams)
        => new ()
        {
            CountParams = indexCallsParams,
            PaginationParams = indexCallsParams
        };
}