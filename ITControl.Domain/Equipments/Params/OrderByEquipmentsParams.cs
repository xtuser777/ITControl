using ITControl.Domain.Shared.Params2;

namespace ITControl.Domain.Equipments.Params;

public record OrderByEquipmentsParams : 
    OrderByParams
{
    public string? Name { get; init; }
    public string? Description { get; init; }
    public string? Ip { get; init; }
    public string? Mac { get; init; }
    public string? Tag { get; init; }
    public string? Rented { get; init; }
    public string? Type { get; init; }
}
