using ITControl.Communication.Shared.Requests;

namespace ITControl.Communication.Equipments.Requests;

public record FindManyEquipmentsRequest : PageableRequest
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Ip { get; set; }
    public string? Mac { get; set; }
    public string? Tag { get; set; }
    public int? Type { get; set; }
    public string? Rented { get; set; }
    public string? OrderByName { get; set; }
    public string? OrderByDescription { get; set; }
    public string? OrderByIp { get; set; }
    public string? OrderByMac { get; set; }
    public string? OrderByTag { get; set; }
    public string? OrderByType { get; set; }
    public string? OrderByRented { get; set; }
}