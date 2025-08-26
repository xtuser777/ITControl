using ITControl.Application.Interfaces;
using ITControl.Application.Translators;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Enums;

namespace ITControl.Application.Views;

public class TreatmentsTypesView : ITreatmentsTypesView
{
    public IEnumerable<TranslatableField> FindMany()
    {
        var treatmentsTypes = Enum.GetValues<TreatmentType>();
        return treatmentsTypes.Select(tt => new TranslatableField()
        {
            Value = tt.ToString(),
            DisplayValue = TreatmentTypeTranslator.ToDisplayName(tt),
        });
    }
}