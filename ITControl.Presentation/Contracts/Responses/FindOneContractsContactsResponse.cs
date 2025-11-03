namespace ITControl.Presentation.Contracts.Responses;

public record FindOneContractsContactsResponse
{
    public Guid? Id { get; init; } 
    public string? Name { get; init; } = string.Empty;
    public string? Email { get; init; } = string.Empty;
    public string? Phone { get; init; } = string.Empty;
    public string? Cellphone { get; init; } = string.Empty;
}