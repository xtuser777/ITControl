using ITControl.Application.Supplements.Interfaces;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Shared.Extensions;
using ITControl.Domain.Supplements.Enums;

namespace ITControl.Application.Supplements.Views;

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
