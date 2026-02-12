using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Supplies.Enums;

namespace ITControl.Domain.Supplies.Props;

public class SupplyProps : Entity
{
    public string? Brand { get; set; }
    public string? Model { get; set; }
    public SupplyType? Type { get; set; }
    public int? QuantityInStock { get; set; }
}