using ITControl.Domain.Equipments.Params;

namespace ITControl.Communication.Equipments.Requests;

public record OrderByEquipmentsRequest
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Ip { get; set; }
    public string? Mac { get; set; }
    public string? Tag { get; set; }
    public string? Type { get; set; }
    public string? Rented { get; set; }

    public static implicit operator OrderByEquipmentsRepositoryParams(OrderByEquipmentsRequest request) =>
        new()
        {
            Name = request.Name,
            Description = request.Description,
            Ip = request.Ip,
            Mac = request.Mac,
            Tag = request.Tag,
            Type = request.Type,
            Rented = request.Rented
        };
}