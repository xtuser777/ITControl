using ITControl.Communication.Shared.Responses;

namespace ITControl.Application.Treatments.Interfaces;

public interface ITreatmentsStatusesView
{
    IEnumerable<TranslatableField> FindMany();
}