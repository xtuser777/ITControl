namespace ITControl.Presentation.Contracts.Responses;

public record FindManyContractsResponse
{
    public Guid Id { get; init; }
    public string ObjectName { get; init; } = string.Empty;
    public DateOnly StartedAt { get; init; }
    public DateOnly? EndedAt { get; init; }
}