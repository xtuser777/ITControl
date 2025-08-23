namespace ITControl.Communication.Contracts.Responses;

public class FindOneContractsContactsResponse
{
    public Guid Id { get; set; } 
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Cellphone { get; set; } = string.Empty;
}