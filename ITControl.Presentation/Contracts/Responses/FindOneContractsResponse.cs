namespace ITControl.Presentation.Contracts.Responses;

public record FindOneContractsResponse
{
    public Guid? Id { get; init; }
    public string? Enterprise { get; init; } = string.Empty;
    public string? ObjectName { get; init; } = string.Empty;
    public DateOnly? StartedAt { get; init; }
    public DateOnly? EndedAt { get; init; }
    public IEnumerable<FindOneContractsContactsResponse> ContractsContacts { get; init; } = [];
}