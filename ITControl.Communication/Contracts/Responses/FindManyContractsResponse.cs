namespace ITControl.Communication.Contracts.Responses;

public class FindManyContractsResponse
{
    public Guid Id { get; set; }
    public string ObjectName { get; set; } = string.Empty;
    public DateOnly StartedAt { get; set; }
    public DateOnly? EndedAt { get; set; }
}