namespace ITControl.Domain.Contracts.Params;

public record UpdateContractContactParams
{
    public string? Name { get; set; } = null;
    public string? Email { get; set; } = null;
    public string? Phone { get; set; } = null;
    public string? Cellphone { get; set; } = null;
}
