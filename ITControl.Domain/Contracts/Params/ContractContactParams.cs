namespace ITControl.Domain.Contracts.Params;

public record ContractContactParams
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Cellphone { get; set; } = string.Empty;
    public Guid ContractId { get; set; } = Guid.Empty;
}
