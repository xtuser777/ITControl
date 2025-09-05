using ITControl.Communication.Shared.Responses;

namespace ITControl.Application.Treatments.Interfaces;

public interface ITreatmentsTypesView
{
    IEnumerable<TranslatableField> FindMany();
}