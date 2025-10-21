using ITControl.Communication.Shared.Requests;
using ITControl.Communication.Shared.Utils;
using ITControl.Domain.Contracts.Params;
using ITControl.Domain.Shared.Params;

namespace ITControl.Communication.Contracts.Requests;

public record FindManyContractsRequest : PageableRequest
{
    public string? ObjectName { get; set; }
    public DateOnly? StartedAt { get; set; }
    public DateOnly? EndedAt { get; set; }

    public static implicit operator FindManyContractsRepositoryParams(FindManyContractsRequest request) =>
        new()
        {
            ObjectName = request.ObjectName,
            StartedAt = request.StartedAt,
            EndedAt = request.EndedAt,
        };

    public static implicit operator CountContractsRepositoryParams(FindManyContractsRequest request) =>
        new()
        {
            ObjectName = request.ObjectName,
            StartedAt = request.StartedAt,
            EndedAt = request.EndedAt
        };

    public static implicit operator PaginationParams(FindManyContractsRequest request)
        => new()
        {
            Page = Parser.ToIntOptional(request.Page),
            Size = Parser.ToIntOptional(request.Size),
        };
}