using ITControl.Presentation.Shared.Responses;

namespace ITControl.Presentation.Treatments.Interfaces;

public interface ITreatmentsTypesView
{
    IEnumerable<TranslatableField> FindMany();
}