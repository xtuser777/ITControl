using ITControl.Application.Treatments.Interfaces;
using ITControl.Application.Treatments.Translators;
using ITControl.Communication.Shared.Responses;
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
            DisplayValue = TreatmentStatusTranslator.ToDisplayName(ts),
        });
    }
}