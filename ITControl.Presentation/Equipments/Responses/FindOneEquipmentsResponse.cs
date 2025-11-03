using ITControl.Presentation.Shared.Responses;

namespace ITControl.Presentation.Equipments.Responses;

public class FindOneEquipmentsResponse
{
    public Guid? Id { get; set; }
    public string? Name { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public string? Ip { get; set; } = string.Empty;
    public string? Mac { get; set; } = string.Empty;
    public string? Tag { get; set; } = string.Empty;
    public TranslatableField? Type { get; set; } = null!;
    public bool? Rented { get; set; }
    public Guid? ContractId { get; set; }
    public FindOneEquipmentsContractResponse? Contract { get; set; }
}