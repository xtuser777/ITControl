using ITControl.Domain.Shared.Extensions;
using ITControl.Domain.Treatments.Enums;
using ITControl.Presentation.Shared.Responses;
using ITControl.Presentation.Treatments.Interfaces;

namespace ITControl.Presentation.Treatments.Views;

public class TreatmentsTypesView : ITreatmentsTypesView
{
    public IEnumerable<TranslatableField> FindMany()
    {
        var treatmentsTypes = Enum.GetValues<TreatmentType>();
        return treatmentsTypes.Select(tt => new TranslatableField()
        {
            Value = tt.ToString(),
            DisplayValue = tt.GetDisplayValue(),
        });
    }
}