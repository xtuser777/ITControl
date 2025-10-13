namespace ITControl.Domain.Equipments.Params;

public record OrderByEquipmentsRepositoryParams
{
    public string? Name { get; set; } = null;
    public string? Description { get; set; } = null;
    public string? Ip { get; set; } = null;
    public string? Mac { get; set; } = null;
    public string? Tag { get; set; } = null;
    public string? Rented { get; set; } = null;
    public string? Type { get; set; } = null;
}
