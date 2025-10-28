using ITControl.Domain.Shared.Extensions;
using ITControl.Domain.Supplements.Enums;
using ITControl.Presentation.Shared.Responses;
using ITControl.Presentation.Supplements.Interfaces;

namespace ITControl.Presentation.Supplements.Views;

public class SupplementsTypesView : ISupplementsTypesView
{
    public IEnumerable<TranslatableField> FindMany()
    {
        return Enum.GetValues(typeof(SupplementType))
            .Cast<SupplementType>()
            .Select(type => new TranslatableField()
            {
                Value = type.ToString(),
                DisplayValue = type.GetDisplayValue()
            });
    }
}
