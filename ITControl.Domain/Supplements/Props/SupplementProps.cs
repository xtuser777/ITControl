using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Supplements.Enums;

namespace ITControl.Domain.Supplements.Props;

public class SupplementProps : Entity
{
    public string? Brand { get; set; }
    public string? Model { get; set; }
    public SupplementType? Type { get; set; }
    public int? QuantityInStock { get; set; }
}