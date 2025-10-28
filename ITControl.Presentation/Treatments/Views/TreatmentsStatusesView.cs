using ITControl.Domain.Shared.Extensions;
using ITControl.Domain.Treatments.Enums;
using ITControl.Presentation.Shared.Responses;
using ITControl.Presentation.Treatments.Interfaces;

namespace ITControl.Presentation.Treatments.Views;

public class TreatmentsStatusesView : ITreatmentsStatusesView
{
    public IEnumerable<TranslatableField> FindMany()
    {
        var treatmentsStatuses = Enum.GetValues<TreatmentStatus>();
        return treatmentsStatuses.Select(ts => new TranslatableField()
        {
            Value = ts.ToString(),
            DisplayValue = ts.GetDisplayValue(),
        });
    }
}