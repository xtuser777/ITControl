namespace ITControl.Communication.Equipments.Requests;

public class UpdateEquipmentsRequest
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Ip { get; set; }
    public string? Mac { get; set; }
    public string? Tag { get; set; }
    public int? Type { get; set; }
    public bool? Rented { get; set; }
    public Guid? ContractId { get; set; }
}