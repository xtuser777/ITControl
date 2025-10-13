using ITControl.Domain.Contracts.Params;

namespace ITControl.Communication.Contracts.Requests;

public record OrderByContractsRequest
{
    public string? ObjectName { get; set; } = null;
    public string? StartedAt { get; set; } = null; // "asc" | "desc"
    public string? EndedAt { get; set; } = null;

    public static implicit operator OrderByContractsRepositoryParams(OrderByContractsRequest request)
    {
        return new OrderByContractsRepositoryParams
        {
            ObjectName = request.ObjectName,
            StartedAt = request.StartedAt,
            EndedAt = request.EndedAt
        };
    }
}
