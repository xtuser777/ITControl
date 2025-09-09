using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Supplements.Enums;

namespace ITControl.Domain.Supplements.Entities;

public sealed class Supplement : Entity
{
    public string Brand { get; set; } = null!;
    public string Model { get; set; } = null!;
    public SupplementType Type { get; set; }
    public int QuantityInStock { get; set; }

    public Supplement()
    {
    }

    public Supplement(string brand, string model, SupplementType type, int quantityInStock)
    {
        Id = Guid.NewGuid();
        Brand = brand;
        Model = model;
        Type = type;
        QuantityInStock = quantityInStock;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public void Update(string? brand = null, string? model = null, SupplementType? type = null, int? quantityInStock = null)
    {
        if (brand is not null)
            Brand = brand;
        if (model is not null)
            Model = model;
        if (type is not null)
            Type = type.Value;
        if (quantityInStock is not null)
            QuantityInStock = quantityInStock.Value;
        UpdatedAt = DateTime.Now;
    }
}
