using ITControl.Application.Supplements.Interfaces;
using ITControl.Communication.Shared.Responses;
using ITControl.Communication.Supplements.Responses;
using ITControl.Domain.Shared.Attributes;
using ITControl.Domain.Shared.Extensions;
using ITControl.Domain.Supplements.Entities;

namespace ITControl.Application.Supplements.Views;

public class SupplementsView : ISupplementsView
{
    public CreateSupplementsResponse? Create(Supplement? supplement)
    {
        if (supplement is null)
            return null;

        return new CreateSupplementsResponse()
        {
            Id = supplement.Id
        };
    }

    public IEnumerable<FindManySupplementsResponse> FindMany(IEnumerable<Supplement>? supplements)
    {
        if (supplements is null)
            return [];

        return supplements.Select(supplement => new FindManySupplementsResponse() 
        {
            Id = supplement.Id,
            Brand = supplement.Brand,
            Model = supplement.Model,
            Type = new TranslatableField()
            {
                Value = supplement.Type.ToString(),
                DisplayValue = supplement.Type.GetDisplayValue()
            },
            Stock = supplement.QuantityInStock
        });
    }

    public FindOneSupplementsResponse? FindOne(Supplement? supplement)
    {
        if (supplement is null)
            return null;

        return new FindOneSupplementsResponse()
        {
            Id = supplement.Id,
            Brand = supplement.Brand,
            Model = supplement.Model,
            Type = new TranslatableField()
            {
                Value = supplement.Type.ToString(),
                DisplayValue = supplement.Type.GetDisplayValue()
            },
            Stock = supplement.QuantityInStock
        };
    }
}
