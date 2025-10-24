using ITControl.Communication.Shared.Requests;
using ITControl.Domain.Contracts.Params;

namespace ITControl.Communication.Contracts.Requests;

public record FindManyContractsRequest : FindManyRequest
{
    public string? ObjectName { get; set; }
    public DateOnly? StartedAt { get; set; }
    public DateOnly? EndedAt { get; set; }

    public static implicit operator FindManyContractsParams(
        FindManyContractsRequest request) =>
        new()
        {
            ObjectName = request.ObjectName,
            StartedAt = request.StartedAt,
            EndedAt = request.EndedAt,
        };

    public static implicit operator CountContractsParams(
        FindManyContractsRequest request) =>
        new()
        {
            ObjectName = request.ObjectName,
            StartedAt = request.StartedAt,
            EndedAt = request.EndedAt
        };
}