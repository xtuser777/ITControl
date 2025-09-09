using ITControl.Application.Treatments.Interfaces;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Shared.Extensions;
using ITControl.Domain.Treatments.Enums;

namespace ITControl.Application.Treatments.Views;

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