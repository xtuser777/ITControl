using ITControl.Application.Interfaces;
using ITControl.Application.Translators;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Enums;

namespace ITControl.Application.Views;

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