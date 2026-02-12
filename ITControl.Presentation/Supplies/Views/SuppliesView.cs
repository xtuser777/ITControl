using ITControl.Domain.Shared.Extensions;
using ITControl.Domain.Supplies.Entities;
using ITControl.Presentation.Shared.Responses;
using ITControl.Presentation.Supplies.Interfaces;
using ITControl.Presentation.Supplies.Responses;

namespace ITControl.Presentation.Supplies.Views;

public class SuppliesView : ISuppliesView
{
    public CreateSuppliesResponse? Create(Supply? supply)
    {
        if (supply is null)
            return null;

        return new CreateSuppliesResponse()
        {
            Id = supply.Id
        };
    }

    public IEnumerable<FindManySuppliesResponse> FindMany(IEnumerable<Supply>? supplies)
    {
        if (supplies is null)
            return [];

        return supplies.Select(supply => new FindManySuppliesResponse() 
        {
            Id = supply.Id,
            Brand = supply.Brand,
            Model = supply.Model,
            Type = new TranslatableField()
            {
                Value = supply.Type.ToString()!,
                DisplayValue = supply.Type!.GetDisplayValue()
            },
            Stock = supply.QuantityInStock
        });
    }

    public FindOneSuppliesResponse? FindOne(Supply? supply)
    {
        if (supply is null)
            return null;

        return new FindOneSuppliesResponse()
        {
            Id = supply.Id,
            Brand = supply.Brand,
            Model = supply.Model,
            Type = new TranslatableField()
            {
                Value = supply.Type.ToString()!,
                DisplayValue = supply.Type!.GetDisplayValue()
            },
            Stock = supply.QuantityInStock
        };
    }
}
