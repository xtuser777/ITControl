using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Equipments.Params;

public record OrderByEquipmentsRepositoryParams : 
    OrderByRepositoryParams
{
    public string? Name { get; init; } = null;
    public string? Description { get; init; } = null;
    public string? Ip { get; init; } = null;
    public string? Mac { get; init; } = null;
    public string? Tag { get; init; } = null;
    public string? Rented { get; init; } = null;
    public string? Type { get; init; } = null;
}
