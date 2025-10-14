using ITControl.Domain.Systems.Params;

namespace ITControl.Communication.Systems.Requests;

public record OrderBySystemsRequest
{
    public string? Name { get; set; }
    public string? Version { get; set; }
    public string? ImplementedAt { get; set; }
    public string? EndedAt { get; set; }
    public string? Own { get; set; }

    public static implicit operator OrderBySystemsRepositoryParams(OrderBySystemsRequest request) =>
        new()
        {
            Name = request.Name,
            Version = request.Version,
            ImplementedAt = request.ImplementedAt,
            EndedAt = request.EndedAt,
            Own = request.Own
        };
}