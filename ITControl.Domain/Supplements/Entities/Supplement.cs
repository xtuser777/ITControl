using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Supplements.Enums;
using ITControl.Domain.Supplements.Params;

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

    public Supplement(SupplementParams @params)
    {
        Id = Guid.NewGuid();
        Brand = @params.Brand;
        Model = @params.Model;
        Type = @params.Type;
        QuantityInStock = @params.QuantityInStock;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public void Update(UpdateSupplementParams @params)
    {
        Brand = @params.Brand ?? Brand;
        Model = @params.Model ?? Model;
        Type = @params.Type ?? Type;
        QuantityInStock = @params.QuantityInStock ?? QuantityInStock;
        UpdatedAt = DateTime.Now;
    }
}
