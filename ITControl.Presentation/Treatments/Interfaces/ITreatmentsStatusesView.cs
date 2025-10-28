using ITControl.Presentation.Shared.Responses;

namespace ITControl.Presentation.Treatments.Interfaces;

public interface ITreatmentsStatusesView
{
    IEnumerable<TranslatableField> FindMany();
}