using ITControl.Communication.Shared.Responses;

namespace ITControl.Communication.Equipments.Responses;

public class FindOneEquipmentsResponse
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Ip { get; set; } = string.Empty;
    public string Mac { get; set; } = string.Empty;
    public string Tag { get; set; } = string.Empty;
    public TranslatableField Type { get; set; } = null!;
    public bool Rented { get; set; }
    public string? ContractId { get; set; }
    public FindOneEquipmentsContractResponse? Contract { get; set; }
}