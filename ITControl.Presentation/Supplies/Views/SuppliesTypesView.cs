using ITControl.Domain.Shared.Extensions;
using ITControl.Domain.Supplies.Enums;
using ITControl.Presentation.Shared.Responses;
using ITControl.Presentation.Supplies.Interfaces;

namespace ITControl.Presentation.Supplies.Views;

public class SuppliesTypesView : ISuppliesTypesView
{
    public IEnumerable<TranslatableField> FindMany()
    {
        return Enum.GetValues(typeof(SupplyType))
            .Cast<SupplyType>()
            .Select(type => new TranslatableField()
            {
                Value = type.ToString(),
                DisplayValue = type.GetDisplayValue()
            });
    }
}
