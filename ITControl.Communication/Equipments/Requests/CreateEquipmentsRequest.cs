namespace ITControl.Communication.Equipments.Requests;

public class CreateEquipmentsRequest
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Ip { get; set; } = string.Empty;
    public string Mac { get; set; } = string.Empty;
    public string Tag { get; set; } = string.Empty;
    public int Type { get; set; }
    public bool Rented { get; set; }
    public Guid? ContractId { get; set; }
}