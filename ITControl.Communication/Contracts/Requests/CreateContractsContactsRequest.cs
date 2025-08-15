namespace ITControl.Communication.Contracts.Requests;

public class CreateContractsContactsRequest
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Cellphone { get; set; } = string.Empty;
}